using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameObjectCheckTest : MonoBehaviour
{
    public GameObject tester;
    public Text _text; 

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
        if (other.CompareTag("Player") && tester == null) {
            tester = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tester = null;
    }
}
