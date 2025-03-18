using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    [SerializeField] Transform[] points;

    [SerializeField] private float moveSpeed;
    //telt points in array
    public float detectionRadius = 5f; // De detectiecirkel rondom de vijand
    public LayerMask playerLayer; // Zorg ervoor dat de speler een aparte layer heeft
    private int pointsIndex;
    private Transform player;
    private bool playerInRange = false;

    void Start()
    {
        transform.position = points[pointsIndex].transform.position;
    }


    void Update()
    {

        DetectPlayer();
        if (playerInRange)
        {
            FollowPlayer();
        }

        else if (pointsIndex <= points.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }

            if (pointsIndex == points.Length)
            {
                pointsIndex = 0;
            }
        }

        void DetectPlayer()
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, detectionRadius, Vector2.zero, 6f, playerLayer);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                player = hit.collider.transform;
                playerInRange = true;

            }
            else
            {
                playerInRange = false;
                //Debug.Log(hit.collider.name);        
            }
        }

        void FollowPlayer()
        {
            if (player == null) return;


            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            transform.right = player.transform.position - transform.position;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}