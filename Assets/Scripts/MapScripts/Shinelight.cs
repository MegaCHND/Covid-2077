using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shinelight : MonoBehaviour
{
    public Light bumpLight;

    private IEnumerator TurnLightOff()
    {
        yield return new WaitForSeconds(.2f);
        bumpLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) {
            bumpLight.enabled = true;
            StartCoroutine(TurnLightOff());
        }
    }
}
