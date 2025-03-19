using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coincount : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public static int coins = 0;

    private void FixedUpdate()
    {
        coinText.text = coins.ToString();
    }
    public static void AddScore()
    {
        coins++;
    }
}
