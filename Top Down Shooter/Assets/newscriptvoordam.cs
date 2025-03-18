using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newscriptvoordam : MonoBehaviour
{
    public int health = 5; // Enemy heeft 5 HP

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) // Controleer of de kogel de enemy raakt
        {
            TakeDamage(1); // Verminder HP met 1
            Destroy(collision.gameObject); // Verwijder de kogel
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy HP: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy destroyed!");
        Destroy(gameObject); // Verwijder de vijand uit de scene
    }
}
