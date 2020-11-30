using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt : MonoBehaviour
{
    public GameObject button;
    bool active;
    void Start () {
        button.SetActive(false);
        active = false;
    }
    void OnTriggerEnter(Collider player) {
        if (player.CompareTag("Player")) {
            active = true;
        }
    }
    void OnTriggerExit(Collider player) {
        if (player.CompareTag("Player")) {
            active = false;
        }
    }
    void Update(){
        button.SetActive(active);
    }
}