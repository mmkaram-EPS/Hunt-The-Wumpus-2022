using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour
{
    public static Take grabar;
    public bool isRight = false;

    List<string> toShuffle = new List<string>();
    List<List<string>> mainThing = new List<List<string>>();
    ArrayList organizedData = new ArrayList();
    List<string> placeholder = new List<string>();
    public Take Q1;
    public Take Q2;
    public Take Q3;
    public Take Q4;
    public Button newButton;
    int j = 0;
    //missing reference on 154
    public GameObject QuestionBox;
    //need to store value of toAnswer in tooAnswer uwu
    public bool toAnswerResult;


    // Start is called before the first frame update
    void Start()
    {
        string[] input = System.IO.File.ReadAllLines(@"C:\Users\jespelien\Documents\GitHub\Hunt-The-Wumpus-2022\data.txt"); //read data from file
        List<string> questions = new List<string>();
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
        List<string> temp = new List<string>(5);
        for (int i = 0; i < input.Length; i = i + 5)
        {
            for (j = 0; j < 5; j++)
            {
                temp.Add(input[i]);
                i++;
            }
            // If we need to read from questions ever, we will uncomment this
            questions.Add(temp[0]); //question
            toShuffle.Add(temp[1]); //right
            toShuffle.Add(temp[2]); //wrong1
            toShuffle.Add(temp[3]); //wrong2
            toShuffle.Add(temp[4]); //wrong3
            toShuffle = Shuffle(toShuffle);
            
            organizedData.Add(toShuffle[i]); //right
            organizedData.Add(toShuffle[i+1]); //wrong1
            organizedData.Add(toShuffle[i+2]); //wrong2
            organizedData.Add(toShuffle[i+3]); //wrong3
        }

        for (int i = 0; i < questions.Count; i++)
        {
            placeholder.Add(questions[i]);
            placeholder.Add(toShuffle[i]);
            placeholder.Add(toShuffle[i + 1]);
            placeholder.Add(toShuffle[i + 2]);
            placeholder.Add(toShuffle[i + 3]);
            mainThing.Add(placeholder);
        }

        j = 0;
        temp.Clear();


        Button BQ1 = Q1.GetComponent<Button>();
        BQ1.onClick.AddListener(tooAnswer);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    //took this pretty straightforward fischer yates shuffle from somewhere
    static List<string> Shuffle(List<string> array)
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
        return array;
    }
//missing this :p

    public void tooAnswer()
    {
        toAnswerResult=toAnswer();
    }

    //removed static to prevent reference error on the globals
    public bool toAnswer()
    {
        if(Q1.isCorrect == true)
        {
            return true;
            Debug.Log("Answer 1 is correct!");
        }
        if (Q2.isCorrect == true)
        {
            return true;
            Debug.Log("Answer 2 is correct!");
        }
        if (Q3.isCorrect == true)
        {
            return true;
            Debug.Log("Answer 3 is correct!");
        }
        if (Q4.isCorrect == true)
        {
            return true;
            Debug.Log("Answer 4 is correct!");
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
            Debug.Log("AYAYA CLAP");
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
