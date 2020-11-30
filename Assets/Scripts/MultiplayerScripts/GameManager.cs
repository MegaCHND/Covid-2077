using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public static Dictionary<int, Interactable> Interactables = new Dictionary<int, Interactable>();
    public static Dictionary<int, EnemyManager> enemies = new Dictionary<int, EnemyManager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    public GameObject interactablesPrefab;
    public GameObject enemyPrefabs;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    /// <summary>Spawns a player.</summary>
    /// <param name="_id">The player's ID.</param>
    /// <param name="_name">The player's name.</param>
    /// <param name="_position">The player's starting position.</param>
    /// <param name="_rotation">The player's starting rotation.</param>
    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    public void createInteractable(int _InteractibleID, Vector3 _position, bool _InteractedWith) {
        GameObject _interactible = Instantiate(interactablesPrefab, _position, interactablesPrefab.transform.rotation);
        _interactible.GetComponent<Interactable>().Initialize(_InteractibleID, _InteractedWith);
        Interactables.Add(_InteractibleID, _interactible.GetComponent<Interactable>());
    }

    public void createEnemy(int _id, Vector3 _position, Quaternion _rotation) {
        GameObject _enemy = Instantiate(enemyPrefabs, _position, _rotation);
        _enemy.GetComponent<EnemyManager>().Initialize(_id);
        enemies.Add(_id, _enemy.GetComponent<EnemyManager>());
    }
}
