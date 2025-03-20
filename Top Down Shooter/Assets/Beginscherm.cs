using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Beginscherm : MonoBehaviour
{
    


    // Geef de naam van de scene die je wilt laden op
    [SerializeField] private string SampleScene_Casper;

    // Functie die je koppelt aan de knop

    // Functie die je koppelt aan de knop
    public void LoadScene()
    {


        SceneManager.LoadScene(SampleScene_Casper);
        
    }
}
