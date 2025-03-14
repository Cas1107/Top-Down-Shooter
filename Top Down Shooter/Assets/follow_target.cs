using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_target : MonoBehaviour
{
    [SerializeField] private GameObject enemy_6;
    [SerializeField] private float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemy_6.transform.position, speed * Time.deltaTime);
        transform.right = enemy_6.transform.position - transform.position;
    }
}