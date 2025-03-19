using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class coinscript : MonoBehaviour
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
