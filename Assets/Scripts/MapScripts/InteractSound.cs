using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSound : MonoBehaviour
{
    public AudioClip aClip;
    public AudioSource aSource;
    public float playTime;

    private bool objectInProximity;
    private float timer;
    private bool playingSound;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.clip = null;
        objectInProximity = false;
        playingSound = false;
    }

    void Update()
    {
        if (playingSound == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                stopSound();
            }
        }

        if (objectInProximity == true && playingSound == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                timer = playTime;
                playSound();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        objectInProximity = true;
    }
    private void OnTriggerExit(Collider other)
    {
        objectInProximity = false;
    }

    void playSound()
    {
        playingSound = true;
        aSource.loop = true;
        aSource.clip = aClip;
        aSource.Play();
    }

    void stopSound()
    {
        playingSound = false;
        aSource.loop = false;
        aSource.clip = null;
        aSource.Stop();
    }
}
