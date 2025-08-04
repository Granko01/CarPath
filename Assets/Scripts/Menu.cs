using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject[] Maps;
    public Button[] LogicButtons;
    public int CurrentMap = 0;
    public GameObject MenuPanel;
    public GameObject ShopPanel;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentMap == 0)
        {
            LogicButtons[1].interactable = false;
            LogicButtons[0].interactable = true;

        }
        else if (CurrentMap == 1)
        {
             LogicButtons[0].interactable = true;
            LogicButtons[1].interactable = true;
        }
        else if (CurrentMap == 2)
        {
            LogicButtons[0].interactable = false;
            LogicButtons[1].interactable = true;
        }
    }

    public void MapMethods(string tags)
    {

        if (CurrentMap == 0)
        {
            LogicButtons[1].interactable = false;
            LogicButtons[0].interactable = true;

        }
        else if (CurrentMap == 2)
        {
            LogicButtons[0].interactable = false;
            LogicButtons[1].interactable = true;
        }
        if (tags == "Next")
        {
            CurrentMap++;
            Maps[CurrentMap].gameObject.SetActive(true);
            Maps[CurrentMap - 1].gameObject.SetActive(false);
        }
        else if (tags == "Previous")
        {
            CurrentMap--;
            Maps[CurrentMap].gameObject.SetActive(true);
            Maps[CurrentMap + 1].gameObject.SetActive(false);
        }
    }

    public void MenuMethod()
    {
        if (MenuPanel.activeSelf)
        {
            MenuPanel.gameObject.SetActive(false);
        }
        MenuPanel.gameObject.SetActive(true);
        ShopPanel.gameObject.SetActive(false);
    }

    public void ShopMethod()
    {
        if (ShopPanel.activeSelf)
        {
            ShopPanel.gameObject.SetActive(false);
        }
        ShopPanel.gameObject.SetActive(true);
        MenuPanel.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void StartGame2()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void StartGame3()
    {
        SceneManager.LoadScene("Scene3");
    }
}
