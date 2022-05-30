using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // 0 coins at the start, 100 to collect
    public int coins = 0;
    // 0 turns at the start
    public int turns = 0;
    // Three arrows by default
    public int arrowCount = 3;
    // Secrets start at 0
    public int secretCount = 0;

    public TextMeshProUGUI counterText;

    void Update()
    {
        string newText = "";
        newText += "<b>(C)</b>" + coins.ToString();
        newText += " <b>(A)</b>" + arrowCount.ToString();
        newText += " <b>(S)</b>" + secretCount.ToString();
        counterText.SetText(newText);
    }
}
