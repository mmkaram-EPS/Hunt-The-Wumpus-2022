using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trivia : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] input = System.IO.File.ReadAllLines(@"C: \Users\jespelien\Documents\GitHub\Hunt - The - Wumpus - 2022\data.txt"); //read data from file
        string[,,] organizedQuestions;
        string[] questions;
        string[] toShuffle;

        /*data is formatted as follows: 
         Question
         Answer 1 (correct)
         Answer 2
         Answer 3
         Answer 4
         */


        //Organize answers into 2d array, answers into separate array to make shuffling easier
        //Each row of the array has a set of 4 answers, correct, wrong1, wrong2, wrong3
        //to be shuffled
        for (int i = 0; i < 350; i = i+5) {
            questions[i] = input[i]; //question
            toShuffle[i] = input[i + 1]; //right
            toShuffle[i + 1] = input[i + 2]; //wrong1
            toShuffle[i + 2] = input[i + 3]; //wrong2
            toShuffle[i + 3] = input[i + 4]; //wrong3
            Shuffle<toShuffle>;


            organizedData[i, 0] = toShuffle[i]; //right
            organizedData[i, 1] = toShuffle[i + 1]; //wrong1
            organizedData[i, 2] = toShuffle[i + 2]; //wrong2
            organizedData[i, 3] = toShuffle[i + 3]; //wrong3
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //took this pretty straightforward fischer yates shuffle from somewhere
    static void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        for (int i = 0; i < (n - 1); i++)
        {
            // Use Next on random instance with an argument.
            // ... The argument is an exclusive bound.
            //     So we will not go past the end of the array.
            int r = i + _random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
//missing this :p
}
