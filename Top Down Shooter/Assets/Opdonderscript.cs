using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdonderscript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // De kogel verdwijnt zodra het iets raakt
        Destroy(gameObject);
    }
}
