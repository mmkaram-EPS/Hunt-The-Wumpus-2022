using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriviaManager : MonoBehaviour
{
    public New_Trivia trivia;
    public GameObject triviaUI;

    [SerializeField]
    private int questionsNeeded = 0;
    [SerializeField]
    private int questionsCorrect = 0;
    [SerializeField]
    private string correctAnswer = "";

    void Start()
    {
        // Set the Ui active to false by default
        triviaUI.SetActive(false);
        // Test Load function
        Load(2, 1);
    }

    public bool Load(int amount, int correctNeeded)
    {
        triviaUI.SetActive(true);

        // Set the questionsNeeded, and start the first question
        questionsNeeded = amount;
        Next();
    }

    void Next()
    {
        // If finished
        if (questionsNeeded == 0)
        {
            // Reset Everything
            questionsNeeded = 0;
            questionsCorrect = 0;
            correctAnswer = "";

            // Set the UI inactive
            triviaUI.SetActive(false);
        }

        questionsNeeded--;
        correctAnswer = trivia.LoadRandomQuestion();
    }

    public void InputAnswer(TextMeshProUGUI answer)
    {
        if (answer.text == correctAnswer)
        {
            questionsCorrect++;

            Debug.Log("Correct");

            // Set up correct UI anim here later
        }

        Next();
    }
}
