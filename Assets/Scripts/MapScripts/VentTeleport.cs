using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentTeleport : MonoBehaviour
{
    public Transform telepoint;
    private bool Epress;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Epress = true;
        }
        else { Epress = false; }
        
    }


    public bool GetE() {
        return Epress;
    }
    public Vector3 getPos() {
        return telepoint.position;
    }
}
