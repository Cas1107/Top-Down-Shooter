using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Sleep hier de speler in vanuit de Inspector
    public Vector3 offset = new Vector3(0, 5, -10); // Pas dit aan voor de gewenste camerahoek

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * 5);

        }
    }
}
