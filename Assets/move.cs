using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            transform.position += new Vector3(0, 0, .5f);
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            transform.position -= new Vector3(0, 0, .5f);
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            transform.position += new Vector3(.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= new Vector3(.5f, 0, 0);
        }
    }
}
