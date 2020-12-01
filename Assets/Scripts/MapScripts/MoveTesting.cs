using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTesting : MonoBehaviour
{
    public float speed = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += (transform.forward * 1) * 3 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (transform.forward * -1) * 3 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += (transform.right * -1) * 3 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (transform.right * +1) * 3 * Time.deltaTime;
        }

    }
}
