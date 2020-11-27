using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser: MonoBehaviour
{
    [SerializeField]
    private GameObject Door;
    [SerializeField]
    private GameObject openDoorTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            closeDoor();
        }
    }

    private void closeDoor() {
        Door.GetComponent<Transform>().Rotate(0, 0, -90, Space.Self);
        openDoorTrigger.GetComponent<BoxCollider>().enabled = true;
    }
}
