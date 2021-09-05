using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPartol : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] wayPoint;

    public enum States { PATROL }

    States currentStates;

    private int currentWayPoint;

    private void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    private void Update()
    {
        DoPatrol();
    }

    private void DoPatrol()
    {
        if (agent.destination != wayPoint[currentWayPoint].position)
        {
            agent.destination = wayPoint[currentWayPoint].position;
            
        }

        if (HasReached())
        {
            currentWayPoint = (currentWayPoint + 1) % wayPoint.Length;
        }
    }

    private bool HasReached()
    {
        return (agent.hasPath && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

    }
}
