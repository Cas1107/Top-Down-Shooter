using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winscript : MonoBehaviour
{
    public List<GameObject> enemies; // Sleep vijanden in als je geen tag gebruikt

    void Start()
    {
        if (enemies.Count == 0)
        {
            enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        }
    }

    void Update()
    {
        CheckEnemies();
    }

    void CheckEnemies()
    {
        enemies.RemoveAll(enemy => enemy == null); // Verwijder dode vijanden uit de lijst

        if (enemies.Count == 0) // Als alle vijanden weg zijn, laad eindscherm
        {
            LoadEndScreen();
        }
    }

    void LoadEndScreen()
    {
        SceneManager.LoadScene("Eindschermloss"); // Zorg dat je een scène met deze naam hebt
    }
}
