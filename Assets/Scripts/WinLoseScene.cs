using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinLoseScene : MonoBehaviour
{
    public string w = "Win";
    public TextMeshProUGUI text;
    public NoteSpawner n;
    public Notes no;
    public GameObject noteGameObj;
    public Text noteTextGameObj;

    void Start()
    {
        n = GameObject.FindWithTag("NoteSpawner").GetComponent<NoteSpawner>();
        no = GameObject.FindWithTag("Note").GetComponent<Notes>();
        text.text = "You " + w + " Score: " + GameObject.FindWithTag("GameManager").GetComponent<GameManager>().score.ToString();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            Application.Quit();
        }
        if (n.notesCollected >= 10){
            noteGameObj.SetActive(true);
            no.loadNotePublic(n.noteTextSecret, noteGameObj, noteTextGameObj);
        }

    }
}
