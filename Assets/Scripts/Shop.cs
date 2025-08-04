using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public int Coins = 1000;
    public int mapIndex = 0;
    public Text[] CoinsText;

    private const string CoinsKey = "CoinsKey";

    public Button[] CarSpeed;
    public Button[] RoadTax;
    public Button Demolition;
    public int Speedstate = 0;
    public int TaxState = 0;
    public int DemolitionInt = 0;

    public Button[] Maps;
    public Button[] StartBtn;
    public Button[] BuyBtn;

    private const string CarStateKey = "Statekey";
    private const string TaxKey = "TaxKey";
    private const string DemolitionKey = "DemoKey";
    private const string MapsKey = "MapsKey";


    void Start()
    {
        GetCoins();
        UpdateAllTexts(CoinsText, Coins);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            GetCar();
            GetTax();
            GetDemo();
            GetMaps();
            Debug.Log("map " + mapIndex);
            UpdateMaps();
            UpdateButtons();
            for (int i = 0; i <= Speedstate; i++)
            {
                CarSpeed[i].interactable = true;
            }
            for (int i = 0; i <= TaxState; i++)
            {
                RoadTax[i].interactable = true;
            }
            if (DemolitionInt == 1)
            {
                Demolition.interactable = true;
            }
        }
    }
    public void GetMaps()
    {
        mapIndex = PlayerPrefs.GetInt(MapsKey, mapIndex);
    }
    public void SetMap()
    {
        PlayerPrefs.SetInt(MapsKey, mapIndex);
        PlayerPrefs.Save();
    }
    public void GetCoins()
    {
        Coins = PlayerPrefs.GetInt(CoinsKey, Coins);
    }
    public void GetCar()
    {
        Speedstate = PlayerPrefs.GetInt(CarStateKey, Speedstate);
    }
    public void GetTax()
    {
        TaxState = PlayerPrefs.GetInt(TaxKey, TaxState);
    }
    public void GetDemo()
    {
        DemolitionInt = PlayerPrefs.GetInt(DemolitionKey, DemolitionInt);
    }
    public void SetCar()
    {
        PlayerPrefs.SetInt(CarStateKey, Speedstate);
        PlayerPrefs.Save();
    }
    public void SetCoins()
    {
        PlayerPrefs.SetInt(CoinsKey, Coins);
        PlayerPrefs.Save();
    }
    public void SetTax()
    {
        PlayerPrefs.SetInt(TaxKey, TaxState);
        PlayerPrefs.Save();
    }
    public void SetDemo()
    {
        PlayerPrefs.SetInt(DemolitionKey, DemolitionInt);
        PlayerPrefs.Save();
    }


    public void Buy(string tags)
    {
        if (tags == "Speed" && Speedstate < 4)
        {
            Speedstate++;
            for (int i = 0; i <= Speedstate; i++)
            {
                CarSpeed[i].interactable = true;
            }
            SetCar();
            Coins -= 100;
            SetCoins();
            UpdateAllTexts(CoinsText, Coins);
        }
        if (tags == "Tax" && TaxState < 4)
        {
            TaxState++;
            for (int i = 0; i <= TaxState; i++)
            {
                RoadTax[i].interactable = true;
            }
            SetTax();
            Coins -= 100;
            SetCoins();
            UpdateAllTexts(CoinsText, Coins);
        }
        if (tags == "Demo" && DemolitionInt < 1)
        {
            DemolitionInt++;
            Demolition.interactable = true;
            SetDemo();
            Coins -= 100;
            SetCoins();
            UpdateAllTexts(CoinsText, Coins);
        }
        if (tags == "SecondMap" && Coins >= 1000)
        {
            Coins -= 1000;
            SetCoins();
            UpdateAllTexts(CoinsText, Coins);
            mapIndex++;
            SetMap();
        }
        if (tags == "ThirdMap" && Coins >= 1000)
        {
            Coins -= 1000;
            SetCoins();
            UpdateAllTexts(CoinsText, Coins);
            mapIndex++;
            SetMap();
        }
         UpdateMaps();
        UpdateButtons();
    }

    public void UpdateMaps()
    {
        for (int i = 0; i <= mapIndex; i++)
        {
            Maps[i].interactable = true;
        }
    }

    public void UpdateButtons()
    {
        if (mapIndex == 1)
        {
            StartBtn[0].interactable = true;
            BuyBtn[0].interactable = false;
        }
        else if (mapIndex == 2)
        {
            StartBtn[1].interactable = true;
            BuyBtn[1].interactable = false;
        }
    }
     public void UpdateAllTexts(Text[] texts, int value)
    {
        foreach (Text t in texts)
        {
            t.text = value.ToString();
        }
    }

}
