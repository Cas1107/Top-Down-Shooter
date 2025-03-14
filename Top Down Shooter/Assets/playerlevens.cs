using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class playerlevens : MonoBehaviour
{
    public int levens = 3; // Start met 3 levens
    public TextMeshProUGUI levensCount; // Verwijzing naar de UI-tekst

    private void Start()
    {
        UpdateLevensUI(); // UI updaten bij start
    }

    private void OnCollisionEnter2D(Collision2D collision) // OnCollisionEnter2D in plaats van OnTriggerEnter2D
    {
        if (collision.gameObject.CompareTag("Enemy")) // Controleer of de speler een vijand raakt
        {
            levens--; // Verminder leven met 1
            UpdateLevensUI(); // Update de UI

            if (levens <= 0)
            {
                GameOver(); // Roep de Game Over functie aan
            }
        }
    }

    void UpdateLevensUI()
    {
        levensCount.text = "Levens: " + levens; // Update de tekst
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        // Voeg hier logica toe voor game over (bijv. restart level)
    }
}

