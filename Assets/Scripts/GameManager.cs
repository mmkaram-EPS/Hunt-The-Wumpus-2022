using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    private GameManager instance;


    void Update()
    {
        string newText = "";
        newText += "<b>(C)</b>" + coins.ToString();
        newText += " <b>(A)</b>" + arrowCount.ToString();
        newText += " <b>(S)</b>" + secretCount.ToString();
        counterText.SetText(newText);
    }

    public void Lose()
    {
        // Haha lose code here
        Debug.Log("LLLLL");
        SceneManager.LoadScene("Death", LoadSceneMode.Additive);
    }

    public void Win(bool wumpus)
    {
        // win state W
        int score = 100;
        score -= turns;
        score += coins;
        score += 5 * arrowCount;
        if(wumpus)
        {
            score += 50;
        }
        SceneManager.LoadScene("Win", LoadSceneMode.Additive);
        Debug.Log(score);
    }
}
