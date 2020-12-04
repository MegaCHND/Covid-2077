using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepSound : MonoBehaviour
{
    public AudioClip[] FootSoundsArray;
    private AudioSource audioSource;
    private Transform Tf;
    private Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        Tf = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        temp = Tf.position;
    }

    private void FixedUpdate()
    {
        if (temp != Tf.position)
        {
            playSound();
        }
    }

    /*Tags for footstep sounds are...
     * Vent
     * carpet
     * tile
     * hardwood
     * pseudo-cement*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vent"))
        {
            audioSource.clip = FootSoundsArray[4];
        }
        else if (other.CompareTag("tile"))
        {
            audioSource.clip = FootSoundsArray[3];
        }
        else if (other.CompareTag("hardwood "))
        {
            audioSource.clip = FootSoundsArray[0];
        }
        else if (other.CompareTag("pseudo-cement "))
        {
            audioSource.clip = FootSoundsArray[2];
        }
        else if (other.CompareTag("carpet "))
        {
            audioSource.clip = FootSoundsArray[1];
        }
    }

    void playSound() {
        audioSource.volume = Random.Range(.8f, 1);
        audioSource.pitch = Random.Range(.8f, 1.1f);
        audioSource.Play();
        temp = Tf.position;
    }
}
