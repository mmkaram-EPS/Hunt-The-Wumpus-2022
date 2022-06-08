using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugMode : MonoBehaviour
{
    public TextMeshProUGUI textObj;
    public GameObject debugUI;
    public GameObject passcodeUI;
    public TriviaManager triviaManager;
    public MobManager mobManager;
    public Player p;

    string passcode = "EPS-TeamC";
    bool hasPassed = false;
    bool open = false;

    void Start()
    {
        debugUI.SetActive(false);
        passcodeUI.SetActive(false);
        open = false;
    }
    void Update()
    {
        if (!open && Input.GetKey("d"))
        {
            OpenDebug();
        }
    }

    public void EnterPasscode(TMP_InputField code)
    {
        if (!hasPassed)
        {
            if (code.text == passcode)
            {
                hasPassed = true;
                passcodeUI.SetActive(false);
                SetDebug();
            } else
            {
                code.text = "";
            }
        }
    }
    public void OpenDebug()
    {
        if (passcodeUI.activeSelf)
        {
            passcodeUI.SetActive(false);
        }

        debugUI.SetActive(!debugUI.activeSelf);
        open = !open;
        p.Freeze();

        if (open)
        {
            SetDebug();
        }
    }
    void SetDebug()
    {
        if (!hasPassed)
        {
            textObj.text = "";
            passcodeUI.SetActive(true);
            return;
        }

        string textToDisplay = "";

        textToDisplay += "Trivia Answer: " + triviaManager.correctAnswer;
        textToDisplay += "\n\nRoom With Wumpus: " + (mobManager.roomWithWumpus + 1).ToString();
        textToDisplay += "\n\nRoom With Bats: " + (mobManager.roomWithBat1 + 1).ToString() + ", " + mobManager.roomWithBat2.ToString();
        textToDisplay += "\n\nRoom With Hole: " + (mobManager.roomWithPit1 + 1).ToString() + ", " + mobManager.roomWithPit2.ToString();

        textObj.text = textToDisplay;
    }
}
