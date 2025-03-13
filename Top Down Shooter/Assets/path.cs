using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    [SerializeField] Transform[] points;

    [SerializeField] private float moveSpeed;
    //telt points in array
    private int pointsIndex;

    void Start()
    {
        transform.position = points[pointsIndex].transform.position;
    }


    void Update()
    {
        if (pointsIndex <= points.Length - 1)
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
    }
}