using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class samenvoegen : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private LayerMask playerLayer;

    private Transform player;
    private bool playerInRange = false;
    private int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        DetectPlayer();

        if (playerInRange)
        {
            FollowPlayer();
        }
        else
        {
            FollowWaypoints();
        }
    }

    void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        if (hit != null && hit.CompareTag("Player"))
        {
            player = hit.transform;
            playerInRange = true;
            Debug.Log("Player gedetecteerd: " + hit.name);
        }
        else
        {
            playerInRange = false;
        }
    }

    void FollowPlayer()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void FollowWaypoints()
    {
        if (waypoints.Length == 0) return;

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
