using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float interactionDistance = 3f;
    private int currentPatrolIndex;
    private NavMeshAgent agent;
    private Transform player;
    private bool isInteracting;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        MoveToNextPatrolPoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= interactionDistance)
        {
            StartInteraction();
        }
        else
        {
            EndInteraction();
        }

        if (!isInteracting)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                MoveToNextPatrolPoint();
            }
        }
    }

    void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
        {
            return;

        }

        agent.destination = patrolPoints[currentPatrolIndex].position;

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void StartInteraction()
    {
        if (!isInteracting)
        {
            Debug.Log("Interaccion con player");
            isInteracting = true;
            agent.isStopped = true;
        }
    }

    void EndInteraction()
    {
        if (isInteracting)
        {
            Debug.Log("Fin de interaccion");
            isInteracting = false;
            agent.isStopped = false;
            MoveToNextPatrolPoint();
        }

    }
}
