using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; 
    public float rayDistance = 0.8f; 
    public LayerMask groundLayer; 

    private Vector3 moveDirection = Vector3.right; 

    void Update()
    {
        
        Vector2 rayOrigin = (Vector2)transform.position + new Vector2(moveDirection.x * 0.5f, 0);

        
        RaycastHit2D hitGrounded = Physics2D.Raycast(rayOrigin, Vector2.down, rayDistance, groundLayer);
        Debug.DrawRay(rayOrigin, Vector2.down * rayDistance, Color.green); 

        
        if (hitGrounded.collider == null)
        {
            Flip();
        }

        
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void Flip()
    {
        moveDirection = -moveDirection; 
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}
