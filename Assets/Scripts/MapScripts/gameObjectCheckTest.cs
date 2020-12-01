using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameObjectCheckTest : MonoBehaviour
{
    public VentTeleport tester;

    private void Update()
    {
        if (tester != null) {
            if (tester.GetE()) {
                tester.gameObject.transform.position = tester.getPos();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        tester = other.GetComponent<VentTeleport>();
    }
    private void OnTriggerExit(Collider other)
    {
        tester = null;
    }
}
