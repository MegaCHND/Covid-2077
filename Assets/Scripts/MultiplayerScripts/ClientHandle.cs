using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        // Now that we have the client's id, connect UDP
        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        if (GameManager.players.TryGetValue(_id, out PlayerManager _player))
        {
            _player.transform.position = _position;
        }
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();
        if (GameManager.players.TryGetValue(_id, out PlayerManager _player))
        {
            _player.transform.rotation = _rotation;
        }
    }

    public static void CreateInteractible(Packet _packet) {
        int _interactibleID = _packet.ReadInt();
        Vector3 interactiblePos = _packet.ReadVector3();
        bool _interactedWith = _packet.ReadBool();

        GameManager.instance.createInteractable(_interactibleID, interactiblePos, _interactedWith); 
    }

    public static void InteracibleTouched(Packet _packet) {
        int _interactibleID = _packet.ReadInt();

        GameManager.Interactables[_interactibleID].InteractibleTouched();
    }

    public static void InteractibleUnTouched(Packet _packet) {
        int _interactibleID = _packet.ReadInt();

        GameManager.Interactables[_interactibleID].InteractableUntouched();
    }

    public static void spawnEnemy(Packet _packet) {
        int _enemyID = _packet.ReadInt();
        Vector3 _EnemyPos = _packet.ReadVector3();
        Quaternion _enemyRot = _packet.ReadQuaternion();
        GameManager.instance.createEnemy(_enemyID, _EnemyPos, _enemyRot);
    }

    public static void enemyPos(Packet _packet)
    {
        int _enemyID = _packet.ReadInt();
        Vector3 _EnemyPos = _packet.ReadVector3();
        Quaternion _EnemyRot = _packet.ReadQuaternion();
        if (GameManager.enemies.TryGetValue(_enemyID, out EnemyManager _enemy)) {
            _enemy.transform.position = _EnemyPos;
            _enemy.transform.rotation = _EnemyRot;
        }
    }

    public static void playerDC(Packet _packet) {
        int _id = _packet.ReadInt();
        Destroy(GameManager.players[_id].gameObject);
        GameManager.players.Remove(_id);
    }
}
