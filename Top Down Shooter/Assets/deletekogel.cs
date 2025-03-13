using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletekogel : MonoBehaviour
{
    public float lifetime = 1f; // De tijd waarna de kogel automatisch wordt vernietigd

    void Start()
    {

        // Vernietig de kogel na de ingestelde levensduur
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;

            Destroy(gameObject);
        }
        // Vernietig de kogel zodra het een object raakt
        Destroy(gameObject);
    }
}
