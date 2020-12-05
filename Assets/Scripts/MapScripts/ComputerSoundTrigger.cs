using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSoundTrigger : MonoBehaviour
{
    public GameObject computer;
    private int playersAmount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            computer.GetComponent<AudioSource>().Play();
            ++playersAmount;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            --playersAmount;
            if (playersAmount <= 0)
            {
                computer.GetComponent<AudioSource>().Stop();
                playersAmount = 0;
            }
        }
    }
}
