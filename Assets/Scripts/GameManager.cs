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
    public Dialog dialog;
    public RoomGen roomGen;
    public MobManager mobManager;
    public New_Trivia triviaData;

    void Update()
    {
        string newText = "";
        newText += "<b>(C)</b>" + coins.ToString();
        newText += " <b>(A)</b>" + arrowCount.ToString();
        counterText.SetText(newText);
    }

    public void Lose()
    {
        // Haha lose code here
        Debug.Log("LLLLL");
        SceneManager.LoadScene("Death");
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
        SceneManager.LoadScene("Win");
        Debug.Log(score);
    }

    public void UseSecret()
    {
        string secret = "";
        int secretType = Random.Range(0, 5);
        int trueFalse = Random.Range(0, 1);

        if(secretType == 0)
        {
            secret += "A bat is in room ";
            if (trueFalse == 1)
            {
                secret += mobManager.roomWithBat1;
            } else
            {
                secret += mobManager.roomWithBat2;
            }
        } else if (secretType == 1)
        {
            secret += "A pit is in room ";
            if (trueFalse == 1)
            {
                secret += mobManager.roomWithPit1;
            }
            else
            {
                secret += mobManager.roomWithPit2;
            }
        } else if (secretType == 2)
        {
            if (roomGen.DistanceTo(roomGen.currentID, mobManager.roomWithWumpus) <= 2)
            {
                secret += "The Wumpus is within 2 rooms ";
            }
            else
            {
                secret += "The Wumpus is not within 2 rooms ";
            }
        } else if (secretType == 3)
        {
            secret += "The Wumpus is in room ";
            secret += mobManager.roomWithWumpus;
        } else if (secretType == 4)
        {
            secret += "You are curently in room ";
            secret += roomGen.currentID;
        } else if (secretType == 5)
        {
            secret += triviaData.RandomBadAnswer();
        }

        dialog.StartText(new string[] { secret });

        secretCount--;
    }
}