using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject[] RoadPrefabs;
  
    public int CoinsWon;
    public int RoadState = 0;

    InGame inGame;


    void Start()
    {
        inGame = FindObjectOfType<InGame>();
    }

    // Update is called once per frame
    void Update()
    {

    }  

    public void OnRoadClick()
    {
        if (RoadState == 1)
        {
            RoadPrefabs[0].gameObject.SetActive(true);
            RoadPrefabs[3].gameObject.SetActive(false);
        }
        else if (RoadState == 2)
        {
            for (int i = 0; i < RoadPrefabs.Length; i++)
            {
                RoadPrefabs[i].gameObject.SetActive(false);
            }
            RoadPrefabs[1].gameObject.SetActive(true);
        }
        else if (RoadState == 3)
        {
            for (int i = 0; i < RoadPrefabs.Length; i++)
            {
                RoadPrefabs[i].gameObject.SetActive(false);
            }
            RoadPrefabs[2].gameObject.SetActive(true);
        }
    }

   
    
     public void IncreaseRoad()
    {
        Debug.Log(inGame.RoadCount);
        if (inGame.RoadCount > 0)
        {
            RoadState++;
            OnRoadClick();
            inGame.RoadCount--;
            inGame.ShowRoad[inGame.RoadCount].gameObject.SetActive(false);
            inGame.ShowBuy[inGame.RoadCount].gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Buy more roads");
        }
    }
}
