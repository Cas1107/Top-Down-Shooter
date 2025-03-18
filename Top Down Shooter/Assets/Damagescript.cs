using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagescript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Controleer of de kogel een vijand raakt
        {
            Enemyy enemy = other.GetComponent<Enemyy>(); // Haal het Enemy-script op
            if (enemy != null)
            {
                enemy.TakeDamage(1); // Verminder de gezondheid van de vijand met 1
            }
            Destroy(gameObject); // Verwijder de kogel na impact
        }
    }
}
