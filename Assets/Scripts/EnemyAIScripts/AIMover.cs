﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    public Transform[] wayPoints;
    public float[] waitTimes;
    public int speed;
    public bool circleMovement;

    private int wayPointIndex;
    private float dist;
    private bool goingForward;
    private bool canMove;
    private int currentSpeed;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        wayPointIndex = 0;
        canMove = true;
        currentSpeed = speed;
        transform.LookAt(wayPoints[wayPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            dist = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
            if (dist < .5f)
            {
                canMove = false;
                timer = waitTimes[wayPointIndex];
                currentSpeed = 0;
            }
            Patrol();
        }

        if (!canMove)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                NextIndex();
                currentSpeed = speed;
                canMove = true;
            }
        }

    }

    void Patrol()
    {
        transform.LookAt(wayPoints[wayPointIndex].position);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    void NextIndex()
    {
        if (circleMovement)
        {
            wayPointIndex++;
            if (wayPointIndex >= wayPoints.Length)
            {
                wayPointIndex = 0;
            }
        }

        if (!circleMovement)
        {
            if (goingForward)
            {
                wayPointIndex++;
                if (wayPointIndex >= wayPoints.Length)
                {
                    wayPointIndex--;
                    goingForward = false;
                }
            }

            if (!goingForward)
            {
                wayPointIndex--;
                if (wayPointIndex < 0)
                {
                    wayPointIndex++;
                    goingForward = true;
                }
            }
        }
    }
}
