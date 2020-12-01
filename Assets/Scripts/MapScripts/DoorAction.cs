using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    public bool isOpen;
    public float rotationDegree;
    public AudioClip ACOpen;
    public AudioClip ACClose;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void openDoor()
    {
        if (!isOpen)
        {
            gameObject.transform.Rotate(0, 0, rotationDegree, Space.Self);
            isOpen = true;
            playOpen();
        }
    }

    public void closeDoor()
    {
        if (isOpen)
        {
            gameObject.transform.Rotate(0, 0, -rotationDegree, Space.Self);
            isOpen = false;
            playClose();
        }
    }

    private void playOpen()
    {
        audioSource.Stop();
        audioSource.clip = ACOpen;
        audioSource.Play();
    }

    private void playClose()
    {
        audioSource.Stop();
        audioSource.clip = ACClose;
        audioSource.Play();
    }
}
