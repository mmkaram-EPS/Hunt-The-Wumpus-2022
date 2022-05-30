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
        ShopOpen();
    }

    public void ShopInput(bool correct, string type)
    {
        Debug.Log(correct);
        if(!correct)
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
        }

        ShopOpen();
    }

    public void PurchaseArrows()
    {
        triviaManager.LoadTrivia(3, 2, ShopInput, "arrow");
    }

    public void PurchaseSecret()
    {
        triviaManager.LoadTrivia(3, 2, ShopInput, "secret");
    }

    public void ShopOpen()
    {
        shopUI.SetActive(!shopUI.activeSelf);
        player.Freeze();
    }
}