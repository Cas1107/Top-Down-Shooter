using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class samenvoegen : MonoBehaviour
{
    public Transform[] waypoints; // Array van waypoints
    public Transform player; // De speler
    public float detectionRange = 5f; // Hoe dichtbij de speler moet zijn om de vijand af te leiden
    public float lostRange = 7f; // Hoe ver de speler moet gaan voordat de vijand stopt met volgen

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private bool chasingPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (chasingPlayer)
        {
            if (distanceToPlayer > lostRange) // Speler is te ver, ga terug naar waypoints
            {
                chasingPlayer = false;
                GoToNextWaypoint();
            }
            else // Blijf de speler volgen
            {
                agent.SetDestination(player.position);
            }
        }
        else
        {
            if (distanceToPlayer < detectionRange) // Speler komt dichtbij, start achtervolging
            {
                chasingPlayer = true;
                agent.SetDestination(player.position);
            }
            else if (!agent.pathPending && agent.remainingDistance < 0.5f) // Bereikt waypoint, ga naar de volgende
            {
                GoToNextWaypoint();
            }
        }
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
