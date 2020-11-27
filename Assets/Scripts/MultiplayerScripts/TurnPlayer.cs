using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer : MonoBehaviour
{
    public float speed = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardFace = transform.forward;
        forwardFace.y = 0;
        forwardFace = forwardFace.normalized;
        if (Input.GetKey(KeyCode.W)) {
            transform.position += (forwardFace * 1) * 3 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (forwardFace * -1) * 3 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
            
    }
}
