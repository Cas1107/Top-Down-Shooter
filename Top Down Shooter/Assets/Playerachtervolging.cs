using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerachtervolging : MonoBehaviour
{
public float detectionRadius = 5f; // De detectiecirkel rondom de vijand
    public float moveSpeed = 2f; // Hoe snel de vijand beweegt
    public LayerMask playerLayer; // Zorg ervoor dat de speler een aparte layer heeft

    private Transform player;
    private bool playerInRange = false;

    void Update()
    {
        DetectPlayer();
        if (playerInRange)
        {
            FollowPlayer();
        }
    }

    void DetectPlayer()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, detectionRadius, Vector2.zero, 0f, playerLayer);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            player = hit.collider.transform;
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

        // Beweeg richting de speler
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    // Om de detectiecirkel te zien in de editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
