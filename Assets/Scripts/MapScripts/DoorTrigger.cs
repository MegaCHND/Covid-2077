using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float waitTime;

    [SerializeField]
    private DoorAction door;
    private float timer;

    //Used to determine if AI is opening door
    public bool openDoor;

    void start()
    {
        openDoor = false;
    }

    void Update()
    {
        if(openDoor)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                door.openDoor();
                openDoor = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(!door.isOpen)
            {
                openDoor = true;
                timer = waitTime;
            }
        }
    }
}
