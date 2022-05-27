using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class New_Trivia : MonoBehaviour
{
    public Object data;

    public List<Question> notDoneQuestion = new List<Question>();

    // Question Text Object
    public TextMeshProUGUI questionText;

    // Button Text Objects
    public TextMeshProUGUI button1;
    public TextMeshProUGUI button2;
    public TextMeshProUGUI button3;
    public TextMeshProUGUI button4;

    // Awake for testing purposes
    void Awake()
    {
        FormatData();
    }

    void FormatData()
    {
        string[] input = System.IO.File.ReadAllLines(AssetDatabase.GetAssetPath(data));

        /*data is formatted as follows: 
         Question
         Answer 1 (correct)
         Answer 2
         Answer 3
         Answer 4
         */

        // For Every single line in the csv
        for (int i = 0; i < input.Length; i++)
        {
            // Create Question Object
            Question question = new Question();

            var delimited = input[i].Split(',');

            foreach (var item in delimited)
            {
                question.data.Add(item);
            }

            notDoneQuestion.Add(question);
        }
    }

    public string LoadRandomQuestion()
    { 
        // Random index
        int index = Random.Range(0, notDoneQuestion.Count);

        // Gets a random question from the list
        Question currQ = notDoneQuestion[index];

        // Set Question Text
        questionText.SetText(currQ.data[0]);

        List<int> randomizedOrder = RandomizeOrder(4);

        // Set the text of all the buttons
        button1.SetText(currQ.data[randomizedOrder[0]]);
        button2.SetText(currQ.data[randomizedOrder[1]]);
        button3.SetText(currQ.data[randomizedOrder[2]]);
        button4.SetText(currQ.data[randomizedOrder[3]]);

        // Removes the question from the list of selectable questions
        notDoneQuestion.RemoveAt(index);
        
        return currQ.data[1];
    }

    List<int> RandomizeOrder(int count)
    {
        // List which picks order of the data
        List<int> normalOrder = new List<int>();

        for (int i = 0; i < count; i++)
        {
            normalOrder.Add(i + 1);
        }

        // Randomized order 
        List<int> randomOrder = new List<int>();

        // Randomly picks and adds item from normalOrder to random order
        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, normalOrder.Count);

            randomOrder.Add(normalOrder[rand]);

            // Cannot pick the same slot twice
            normalOrder.RemoveAt(rand);
        }

        return randomOrder;
    }
}

    public class Question
    {
        /*data is formatted as follows: 
             Question
             Answer 1 (correct)
             Answer 2
             Answer 3
             Answer 4
             */
        public List<string> data = new List<string>();
    }

