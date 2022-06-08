using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    public int ID;
    public bool NoteOpen;
    public GameObject continueTxt;
    public GameObject noteSpawner;
    // Start is called before the first frame update
    void Start()
    {
        noteSpawner = GameObject.Find("Notes");
        continueTxt = noteSpawner.transform.GetChild(0).transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (NoteOpen){
            noteClose(noteSpawner.GetComponent<NoteSpawner>().noteObj, noteSpawner.GetComponent<NoteSpawner>().noteTextObj);
        }
    }
    public void loadNotePublic(string noteTXT, GameObject note, Text noteTXTObj){
        StartCoroutine(loadNote(noteTXT, note, noteTXTObj));
    }
    IEnumerator loadNote(string noteTXT, GameObject note, Text noteTXTObj)
    {
        note.SetActive(true);

        noteTXTObj.text = " ";
        noteTXTObj.gameObject.SetActive(true);
        for (int i = 0; i < noteTXT.Length; i++)
        {
            noteTXTObj.text += noteTXT[i];
            yield return new WaitForSeconds(0.05f);

            if (noteTXT[i] == ' ')
            {
                yield return new WaitForSeconds(0.02f);
            }
        }
        yield return new WaitForSeconds(2f);
        NoteOpen = true;
        if (!NoteOpen){
            continueTxt.SetActive(true);
        }


    }
    public void noteClose(GameObject note, Text noteTXTObj){
        if (Input.GetKeyDown(KeyCode.Space)){
            note.SetActive(false);
            noteTXTObj.gameObject.SetActive(false);
            continueTxt.SetActive(false);
            NoteOpen = false;
        }
    }
}
