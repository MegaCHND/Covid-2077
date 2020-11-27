using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField]
    private GameObject Door;
    [SerializeField]
    private GameObject openDoorTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            openDoor();
        }
    }

    private void openDoor()
    {
        Door.GetComponent<Transform>().Rotate(0, 0, 90, Space.Self);
        openDoorTrigger.GetComponent<BoxCollider>().enabled = false;
    }
}
