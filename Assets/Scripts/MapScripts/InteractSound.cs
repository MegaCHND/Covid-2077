using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSound : MonoBehaviour
{
    public AudioClip aClip;
    public AudioSource aSource;
    public BeepBeep Beeper;
    public float playTime;
    public bool playedSound;

    private GameObject objectInProximity;
    private float timer;
    private bool playingSound;
    
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        objectInProximity = null;
        playingSound = false;
        playedSound = false;
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
        if (objectInProximity != null) {
            if (objectInProximity.CompareTag("Player") && playingSound == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    timer = playTime;
                    playSound();
                    if (Beeper != null) {
                        Beeper.enabled = false;
                    } 
                }
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        objectInProximity = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        objectInProximity = null;
    }

    void playSound()
    {
        if ((CompareTag("Vent") || CompareTag("Comp")) && !playedSound) {
            playingSound = true;
            aSource.loop = true;
            playedSound = true;
            aSource.clip = aClip;
            aSource.Play();
        }
        else if(CompareTag("Locker"))
        {
            playingSound = true;
            aSource.loop = true;
            playedSound = true;
            aSource.clip = aClip;
            aSource.Play();
        }
          
    }

    void stopSound()
    {
        playingSound = false;
        aSource.loop = false;
        aSource.clip = null;
        aSource.Stop();
    }
}
