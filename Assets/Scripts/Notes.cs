using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.ID ==1){

        }
        
    }
    public void loadNotePublic(string noteTXT, GameObject note, Text noteTXTObj){
        StartCoroutine(loadNote(noteTXT, note, noteTXTObj));
    }
    IEnumerator loadNote(string noteTXT, GameObject note, Text noteTXTObj)
    {

        note.SetActive(true);

        noteTXTObj.text = "";
        for (int i = 0; i < noteTXT.Length; i++)
        {
            noteTXTObj.text += noteTXT[i];
            yield return new WaitForSeconds(0.05f);

            if (noteTXT[i] == ' ')
            {
                yield return new WaitForSeconds(0.02f);
            }
        }

        yield return new WaitForSeconds(5f);

        note.SetActive(false);
    }
}
