using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIPathing : MonoBehaviour
{
    //Used to find waypoints
    public Transform[] wayPoints;
    private int wayPointIndex;

    //ini
    NavMeshAgent agent;

    //Patrolling
    public Vector3 walkPoint;
    private bool walkPointSet;
    private bool goingForward; //used to scout back and forth


    //Chasing
    private Transform target = null;
    public float chaseRange;
    private bool isChasing;



    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        wayPointIndex = 0;
        walkPointSet = false;
        goingForward = true;
        isChasing = false;
        transform.LookAt(wayPoints[wayPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && isChasing == true)
        {
            Chasing();
        }
        else
        {
            Patrolling();
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToNextPoint = transform.position - walkPoint;
        //Walkpoint Reached
        if (distanceToNextPoint.magnitude < 1f)
        {
            walkPointSet = false;
            NextIndex();
        }
    }

    private void SearchWalkPoint()
    {
        walkPoint = wayPoints[wayPointIndex].position;
        walkPointSet = true;
    }

    private void NextIndex()
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

        transform.LookAt(wayPoints[wayPointIndex].position);
    }

    private void Chasing()
    {

        float distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distanceFromTarget > chaseRange)
        {
            target = null;
            isChasing = false;
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.transform;
            isChasing = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        /*if (other.tag == "Player")
        {
            target = null;
        }*/
    }
}
