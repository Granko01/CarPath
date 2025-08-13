using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public Transform[] GoTo;
    public GameObject CarOBJ;
    public float moveSpeed = 2f;
    public bool Move = false;
    public GameObject YouWon;
    public GameObject YouLose;
    public GameObject Info;

    public Shop shop;

    public Energy energy;

    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator MoveCarToTargets()
    {
        foreach (var target in GoTo)
        {
            while (Vector3.Distance(CarOBJ.transform.position, target.position) > 0.05f)
            {
                CarOBJ.transform.position = Vector3.MoveTowards(
                    CarOBJ.transform.position,
                    target.position,
                    moveSpeed * Time.deltaTime
                );
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    public void MoveCarMeth()
    {
        Move = true;
        Image img = GetComponent<Image>();
        img.enabled = true;
        StartCoroutine(MoveCarToTargets());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "first")
        {
            Debug.Log("First");
            shop.Coins += 30;
            shop.UpdateAllTexts(shop.CoinsText, shop.Coins);
            shop.SetCoins();
            StartCoroutine(ActivateChildrenTemporarily(collision.gameObject));
        }
        else if (collision.tag == "second")
        {
            Debug.Log("second");
            shop.Coins += 60;
            shop.UpdateAllTexts(shop.CoinsText, shop.Coins);
            shop.SetCoins();
            StartCoroutine(ActivateChildrenTemporarily(collision.gameObject));
        }
        else if (collision.tag == "third")
        {
            Debug.Log("third");
            shop.Coins += 90;
            shop.UpdateAllTexts(shop.CoinsText, shop.Coins);
            shop.SetCoins();
            StartCoroutine(ActivateChildrenTemporarily(collision.gameObject));
        }
        else if (collision.tag == "win")
        {
            Debug.Log("You Won");
            StartCoroutine(ShowWin());
        }
        else if (collision.tag == "lose")
        {
            Debug.Log("You Lose");
            energy.UseEnergy();
            StartCoroutine(ShowLose());
        }
    }

    IEnumerator ActivateChildrenTemporarily(GameObject parent)
    {
        yield return new WaitForSeconds(1f);
        foreach (Transform child in parent.transform)
        {
            child.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(1f);

        foreach (Transform child in parent.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    IEnumerator ShowWin()
    {
        YouWon.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }
    IEnumerator ShowLose()
    {
        YouLose.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Menu");
    }
    public void InfoShow()
    {
        if (Info.activeSelf)
        {
            Info.gameObject.SetActive(false);
        }
        else
        {
            Info.gameObject.SetActive(true);
        }
    }
}
