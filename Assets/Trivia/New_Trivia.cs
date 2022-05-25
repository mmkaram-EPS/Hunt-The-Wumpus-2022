using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class New_Trivia : MonoBehaviour
{
    public Object data;

    public List<Question> dataFormatted = new List<Question>();

    // Start is called before the first frame update
    void Start()
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

            dataFormatted.Add(question);
        }
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
