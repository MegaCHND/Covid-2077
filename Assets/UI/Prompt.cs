using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt : MonoBehaviour
{
    [SerializeField] private Button customButton;

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            customButton.enabled = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            customButton.enabled = false;
        }
    }
}
