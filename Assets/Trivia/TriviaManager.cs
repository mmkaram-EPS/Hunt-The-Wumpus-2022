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
        StartCoroutine(Load(2, 1));
    }

    // Coroutine Because we need to wait until the cycle is finished
    public IEnumerator Load(int amount, int correctNeeded)
    {
        triviaUI.SetActive(true);

        finished = false;

        // Set the questionsNeeded, and start the first question
        questionsNeeded = amount;
        Next();


        // Wait until finished
        yield return new WaitUntil(() => finished);

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

            yield return true;
        }

        // Reset Everything
        questionsNeeded = 0;
        questionsCorrect = 0;
        correctAnswer = "";

        // Set the UI inactive
        triviaUI.SetActive(false);

        yield return false;
    }

    void Next()
    {
        // If finished
        if (questionsNeeded == 0)
        {
            finished = true;
            return;
        }

        // Load the next question
        questionsNeeded--;
        correctAnswer = trivia.LoadRandomQuestion();
    }

    public void InputAnswer(TextMeshProUGUI answer)
    {
        // Check if the answer is true
        if (answer.text == correctAnswer)
        {
            // Update the questions correct count
            questionsCorrect++;

            Debug.Log("Correct");

            // Set up correct UI anim here later
        }

        // Call the next question
        Next();
    }

}
