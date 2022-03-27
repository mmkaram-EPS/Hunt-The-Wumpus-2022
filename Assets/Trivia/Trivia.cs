using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trivia : MonoBehaviour
{
    public static Take grabar;
    public bool isRight = false;

    List<string> questions;
    List<string> toShuffle;
    List<List<string>> mainThing;
    ArrayList organizedData = new ArrayList();
    List<string> placeholder;
    public static Take Q1;
    public static Take Q2;
    public static Take Q3;
    public static Take Q4;
    GameObject QuestionBox;


    // Start is called before the first frame update
    void Start()
    {
        string[] input = System.IO.File.ReadAllLines(@"C: \Users\jespelien\Documents\GitHub\Hunt - The - Wumpus - 2022\data.txt"); //read data from file
        /*data is formatted as follows: 
         Question
         Answer 1 (correct)
         Answer 2
         Answer 3
         Answer 4
         */

        //list = [[Question, [q, a], [q, a], [q, a], [q,a]], etc.]

        //Organize answers into 2d array, answers into separate array to make shuffling easier
        //Each row of the array has a set of 4 answers, correct, wrong1, wrong2, wrong3
        //to be shuffled

        for (int i = 0; i < 350; i = i+5) {
            // If we need to read from questions ever, we will uncomment this
            questions[i] = input[i]; //question
            toShuffle[i] = input[i + 1]; //right
            toShuffle[i + 1] = input[i + 2]; //wrong1
            toShuffle[i + 2] = input[i + 3]; //wrong2
            toShuffle[i + 3] = input[i + 4]; //wrong3
            Shuffle(toShuffle);

            organizedData.Add(toShuffle[i]); //right
            organizedData.Add(toShuffle[i]); //wrong1
            organizedData.Add(toShuffle[i]); //wrong2
            organizedData.Add(toShuffle[i]); //wrong3
        }

        for (int i = 0; i < questions.Count; i++)
        {
            placeholder.Add(questions[i]);
            placeholder.Add(toShuffle[i]);
            placeholder.Add(toShuffle[i+1]);
            placeholder.Add(toShuffle[i+2]);
            placeholder.Add(toShuffle[i + 3]);
            mainThing.Add(placeholder);
        }
   


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //took this pretty straightforward fischer yates shuffle from somewhere
    static void Shuffle(List<string> array)
    {
        int n = array.Count;
        for (int i = 0; i < (n - 1); i++)
        {
            // Use Next on random instance with an argument.
            // ... The argument is an exclusive bound.
            //     So we will not go past the end of the array.
            int r = i + Random.Range(0, n - i);
            string t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
//missing this :p

    public static bool toAnswer()
    {
        if(Q1.isCorrect == true)
        {
            return true;
        }
        if (Q2.isCorrect == true)
        {
            return true;
        }
        if (Q3.isCorrect == true)
        {
            return true;
        }
        if (Q4.isCorrect == true)
        {
            return true;
        }
        return false;
    }

    public void chooseRandom()
    {
        List<string> use;
        use = mainThing[Random.Range(0, mainThing.Count)];
        Q1.button.GetComponent<UnityEngine.UI.Text>().text = mainThing[0][1];
        if(mainThing[0][1] == organizedData[0])
        {
            Q1.isCorrect = true;
        }
        Q2.button.GetComponent<UnityEngine.UI.Text>().text = mainThing[0][2];
        if (mainThing[0][2] == organizedData[0])
        {
            Q2.isCorrect = true;
        }
        Q3.button.GetComponent<UnityEngine.UI.Text>().text = mainThing[0][3];
        if (mainThing[0][3] == organizedData[0])
        {
            Q3.isCorrect = true;
        }
        Q4.button.GetComponent<UnityEngine.UI.Text>().text = mainThing[0][4];
        if (mainThing[0][4] == organizedData[0])
        {
            Q4.isCorrect = true;
        }
        QuestionBox.GetComponent<UnityEngine.UI.Text>().text = mainThing[0][0];
    }
}
