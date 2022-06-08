using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;


public delegate void TriviaInput(bool correct, string type);

public class TriviaManager : MonoBehaviour
{
    public GameManager manager;

    public New_Trivia trivia;
    public GameObject triviaUI;
    public Dialog d;

    private int questionsNeeded = 0;
    private int questionsCorrect = 0;
    public string correctAnswer = "";

    private bool finished = false;

    public Player player;

    void Start()
    {
        triviaUI.SetActive(false);
    }

    public void LoadTrivia(int amount, int correctNeeded, TriviaInput target, string type)
    {
        if (manager.coins == -1)
        {
           manager.Lose();
        }
        StartCoroutine(Load(amount, correctNeeded, target, type));
    }

    // Coroutine Because we need to wait until the cycle is finished
    IEnumerator Load(int amount, int correctNeeded, TriviaInput target, string type)
    {
        triviaUI.SetActive(true);

        finished = false;

        // Set the questionsNeeded, and start the first question
        questionsNeeded = amount;
        Next();

        // Wait until finished
        yield return new WaitUntil(() => finished);

        // Check if enough are correct
        if (questionsCorrect >= correctNeeded)
        {
            Debug.Log("right");
            target(true, type);
        }
        else
        {
            target(false, type);
        }

        // Reset Everything
        questionsNeeded = 0;
        questionsCorrect = 0;
        correctAnswer = "";
        //manager.coins--;

        // Set the UI inactive
        triviaUI.SetActive(false);
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

            d.StartText(new string[] { "Correct" });

            // Set up correct UI anim here later
        }

        // IF ANYONE WANTS TO PUT ANIMATIONS, PUT THEM HERE

        // Call the next question
        Next();
    }

}
