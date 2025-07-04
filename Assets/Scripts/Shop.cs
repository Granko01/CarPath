using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int Coins = 1000;

    public Text[] CoinsText;

    private const string CoinsKey = "CoinsKey";


    void Start()
    {
        GetCoins();
        UpdateAllTexts(CoinsText, Coins);
    }

    public void GetCoins()
    {
        Coins = PlayerPrefs.GetInt(CoinsKey, Coins);
    }
    public void SetCoins()
    {
        PlayerPrefs.SetInt(CoinsKey, Coins);
        PlayerPrefs.Save();
    }

    public void UpdateAllTexts(Text[] texts, int value)
    {
        foreach (Text t in texts)
        {
            t.text = value.ToString();
        }
    }
}
