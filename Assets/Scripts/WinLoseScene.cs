using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseScene : MonoBehaviour
{
    public string w = "Win";
    public TextMeshProUGUI text;

    void Start()
    {
        text.text = "You " + w + " Score: " + GameObject.FindWithTag("GameManager").GetComponent<GameManager>().score.ToString();
    }
}
