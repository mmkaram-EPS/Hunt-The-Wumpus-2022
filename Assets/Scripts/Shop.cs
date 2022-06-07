using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TriviaManager triviaManager;
    public GameManager manager;

    public GameObject shopUI;

    public Player player;

    void Start()
    {
        shopUI.SetActive(false);
    }

    public void ShopInput(bool correct, string type)
    {
        shopUI.SetActive(true);
        manager.turns++;

        if (!correct)
        {
            return;
        }
        if(type == "arrow")
        {
            manager.arrowCount++;
        }
        else if (type == "secret")
        {
            manager.secretCount++;
            manager.UseSecret();
        }
    }

    public void PurchaseArrows()
    {
        shopUI.SetActive(false);
        triviaManager.LoadTrivia(3, 2, ShopInput, "arrow");
    }

    public void PurchaseSecret()
    {
        shopUI.SetActive(false);
        triviaManager.LoadTrivia(3, 2, ShopInput, "secret");
        player.Reset();
    }

    public void ShopOpen()
    {
        shopUI.SetActive(!shopUI.activeSelf);
        if (shopUI.activeSelf)
        {
            player.Reset();
        }
        player.Freeze();
    }
}