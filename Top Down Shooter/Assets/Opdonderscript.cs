using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdonderscript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(gameObject); // Verwijder de bullet
        
    }
}
