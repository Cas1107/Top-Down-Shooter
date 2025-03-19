using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winscript : MonoBehaviour
{
    public List<GameObject> enemies; // Lijst van vijanden
    public List<GameObject> coins;   // Lijst van coins

    void Start()
    {
        if (enemies.Count == 0)
        {
            enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy")); // Voeg vijanden toe die de tag "Enemy" hebben
        }

        if (coins.Count == 0)
        {
            coins.AddRange(GameObject.FindGameObjectsWithTag("coin")); // Voeg coins toe die de tag "Coin" hebben
        }
    }

    void Update()
    {
        CheckGameStatus(); // Controleer zowel de vijanden als de coins elke frame
    }

    void CheckGameStatus()
    {
        // Verwijder dode vijanden en verzamelde coins uit de lijsten
        enemies.RemoveAll(enemy => enemy == null);
        coins.RemoveAll(coin => coin == null);

        // Als er geen vijanden en geen coins meer zijn, laad het eindscherm
        if (enemies.Count == 0 && coins.Count == 0)
        {
            LoadEndScreen();
        }
    }

    void LoadEndScreen()
    {
        SceneManager.LoadScene("Eindschermloss"); // Zorg ervoor dat je een scène hebt met deze naam voor winst
    }
}
