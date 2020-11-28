﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 dir;

    private void Update(){
        dir.z = playerTransform.eulerAngles.y;
        transform.localEulerAngles = dir;
    }
}
