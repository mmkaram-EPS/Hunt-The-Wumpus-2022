using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

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

    private bool finished = false;

    void Start()
    {
        // Test Load function
        Load(2, 1);
    }

    public bool Load(int amount, int correctNeeded)
    {
        triviaUI.SetActive(true);

        finished = false;

        // Set the questionsNeeded, and start the first question
        questionsNeeded = amount;
        Next();

        // Wait until finished
        StartCoroutine(WaitUntilFinished());

        // Check if enough are correct
        if (questionsNeeded >= correctNeeded)
        {
            // Reset Everything
            questionsNeeded = 0;
            questionsCorrect = 0;
            correctAnswer = "";
            finished = false;

            // Set the UI inactive
            triviaUI.SetActive(false);

            return true;
        }

        // Reset Everything
        questionsNeeded = 0;
        questionsCorrect = 0;
        correctAnswer = "";

        // Set the UI inactive
        triviaUI.SetActive(false);

        return false;
    }

    void Next()
    {
        // If finished
        if (questionsNeeded == 0)
        {
            finished = true;
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

    IEnumerator WaitUntilFinished()
    {
        yield return new WaitWhile(() => finished);
    }
}
