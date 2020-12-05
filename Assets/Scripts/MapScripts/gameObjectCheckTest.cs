using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameObjectCheckTest : MonoBehaviour
{
    public GameObject tester;
    public Text _text;

    private void Start()
    {
        _text = GameObject.Find("InteractText").GetComponent<Text>();
    }
    private void Update()
    {
        if (tester != null)
        {
            _text.enabled = true;
        }
        else {
            _text.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Vent") || other.CompareTag("Comp") || other.CompareTag("Locker")) && tester == null) {
            tester = other.gameObject;
            if ((other.CompareTag("Vent") || other.CompareTag("Comp")) && tester.GetComponent<InteractSound>().playedSound) {
                tester = null;
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tester = null;
    }
}
