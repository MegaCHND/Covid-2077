using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shinelight : MonoBehaviour
{
    public Light bumpLight;
    public float onTime = 5f;
    public float offTime = 15f;
    private float timer;
    public bool LightsOn;

    private void Start()
    {
        timer = offTime;
        LightsOn = false;
        bumpLight.enabled = false;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && LightsOn) {
            timer = offTime;
            LightsOn = false;
            bumpLight.enabled = false;
        }
        else if (timer < 0 && !LightsOn) {
            timer = onTime;
            LightsOn = true;
            bumpLight.enabled = true;
        }
    }
}
