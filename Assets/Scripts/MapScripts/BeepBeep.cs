using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepBeep : MonoBehaviour
{
    public AudioClip beep;
    public AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = beep;
        source.loop = true;
        source.Play();
    }
}
