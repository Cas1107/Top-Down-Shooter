using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class deletekogel : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("hoi");
    }
    public float lifetime = 1f; // Hoe lang de kogel blijft bestaan voordat deze vanzelf verdwijnt
    //void OnCollisionEnter(Collision collision)
    //{

    //    // Controleer of de kogel een object raakt
    //    if (collision.gameObject)
    //    {
    //        Debug.Log("!");
    //        // Vernietig de kogel bij impact
    //        Destroy(gameObject);
    //    }
    //}
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Botsing gedetecteerd met: " + collision.gameObject.name);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger geactiveerd door: " + other.gameObject.name);
    }

}
