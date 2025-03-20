using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerlevens : MonoBehaviour
{

    public int levens = 3; // Start met 3 levens
    public TextMeshProUGUI levensCount; // Verwijzing naar de UI-tekst
    private bool kanGehitWorden = true; // Voorkomt snelle opeenvolgende hits

    private void Start()
    {
        UpdateLevensUI(); // UI updaten bij start
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && kanGehitWorden) // Controleer of de speler geraakt kan worden
        {
            levens--; // Verminder leven met 1
            UpdateLevensUI(); // Update de UI

            if (levens <= 0)
            {
                
                GameOver(); // Roep de Game Over functie aan
            }
            else
            {
                StartCoroutine(HerstelTijd()); // Start herstelperiode
            }
        }
    }

    IEnumerator HerstelTijd()
    {
        kanGehitWorden = false; // Zet hitbox tijdelijk uit
        yield return new WaitForSeconds(0.2f); // Wacht 0.5 seconden
        kanGehitWorden = true; // Speler kan weer geraakt worden
    }

    void UpdateLevensUI()
    {
        levensCount.text = levens.ToString(); // Update de tekst
    }

    void GameOver()
    {
        //coins = 0;

        coincount.coins = 0;

        SceneManager.LoadScene("Eindschermwin"); // Laad de eindscherm-scène
    }
}

