using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{

      public GameObject[] ShowBuy;
     public GameObject[] ShowRoad;

     public int RoadCount = 0;
    public Shop shop;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyRoad(string tags)
    {
        if (tags == "First")
        {
            if (shop.Coins >= 250 && RoadCount <= 3)
            {
                shop.Coins -= 250;
                shop.SetCoins();
                shop.UpdateAllTexts(shop.CoinsText, shop.Coins);
                RoadCount++;
                ShowBuy[0].gameObject.SetActive(false);
                ShowRoad[0].gameObject.SetActive(true);
            }
        }
        if (tags == "Second" && RoadCount == 1)
        {
            if (shop.Coins >= 250)
            {
                shop.Coins -= 250;
                shop.SetCoins();
                shop.UpdateAllTexts(shop.CoinsText, shop.Coins);
                RoadCount++;
                ShowBuy[1].gameObject.SetActive(false);
                ShowRoad[1].gameObject.SetActive(true);
            }
        }
         if (tags == "Third" && RoadCount == 2)
        {
            if (shop.Coins >= 250)
            {
                shop.Coins -= 250;
                shop.SetCoins();
                shop.UpdateAllTexts(shop.CoinsText, shop.Coins);
                RoadCount++;
                  ShowBuy[2].gameObject.SetActive(false);
                ShowRoad[2].gameObject.SetActive(true);
            }
        }
    }
}
