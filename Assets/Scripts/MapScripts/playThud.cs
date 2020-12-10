using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playThud : MonoBehaviour
{
    public AudioClip aClip;
    public AudioSource aSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) {
            aSource.clip = aClip;
            aSource.Play();
        }
    }
}
