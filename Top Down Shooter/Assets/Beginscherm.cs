using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Beginscherm : MonoBehaviour
{
    


    // Geef de naam van de scene die je wilt laden op
    [SerializeField] private string SampleScene_Casper;

    // Functie die je koppelt aan de knop
    public void LoadScene()
    {
        // Laadt de scene met de opgegeven naam
        SceneManager.LoadScene(SampleScene_Casper);
        
    }
}
