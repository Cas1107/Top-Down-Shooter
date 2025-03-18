using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private LayerMask playerLayer;

    private int pointsIndex = 0;
    private Transform player;
    private bool playerInRange = false;

    void Start()
    {
        transform.position = points[pointsIndex].position;
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
        if (points.Length == 0) return;

        transform.position = Vector2.MoveTowards(transform.position, points[pointsIndex].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, points[pointsIndex].position) < 0.1f)
        {
            pointsIndex = (pointsIndex + 1) % points.Length;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}