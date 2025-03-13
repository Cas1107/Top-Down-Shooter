using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerwalk : MonoBehaviour
{
    public float plMaxSpeed = 5f;
    public float moveForce = 10f;
    private Rigidbody2D rb;
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(left))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(right))
        {
            horizontalInput = 1f;
        }

        if (Input.GetKey(down))
        {
            verticalInput = -1f;
        }
        else if (Input.GetKey(up))
        {
            verticalInput = 1f;
        }

        rb.velocity = new Vector2(horizontalInput * plMaxSpeed, verticalInput * plMaxSpeed);

        if (Mathf.Abs(rb.velocity.x) < plMaxSpeed)
        {
            rb.AddForce(new Vector2(horizontalInput * moveForce, 0f), ForceMode2D.Force);
        }

        if (Mathf.Abs(rb.velocity.y) < plMaxSpeed)
        {
            rb.AddForce(new Vector2(0f, verticalInput * moveForce), ForceMode2D.Force);
        }
    }
}
