using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nogeencoin : MonoBehaviour
{

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collosion)
    {
        if (collosion.CompareTag("coin"))
        {
            coincount.AddScore();
            Destroy(gameObject);
        }
    }
}
