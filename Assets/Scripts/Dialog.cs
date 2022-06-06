using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialogBox;
    public GameObject holder;
    public Player player;

    bool ok = false;
    bool isCycle = false;

    void Start()
    {
        //StartText(new string[] {"Hello", "I am robot"});
    }

    public void StartText(string[] input)
    {
        holder.SetActive(true);
        player.Freeze();
        StartCoroutine(LoadText(input));
    }

    IEnumerator LoadText(string[] input)
    {
        // Wait until previous cycle is over
        if(isCycle)
        {
            // Wait until
            yield return new WaitUntil(() => !isCycle);
        }

        // Only go if its not cycle yet
        if(!isCycle)
        {
            isCycle = true;
            // Keep doing dialogs until we are done with the array
            for (int j = 0; j < input.Length; j++)
            {
                // Reset the Text
                dialogBox.SetText("");
                // Kinda Smooth Anim thing
                for (int i = 0; i < input[j].Length; i++)
                {
                    dialogBox.text += input[j][i];
                    yield return new WaitForSeconds(0.1f);
                }

                // Wait until they press next
                yield return new WaitUntil(() => ok);

                // Set pressedNext back to false;
                ok = false;
            }


            // Unfreeze the player, reset the dialog box, disable the UI
            player.Freeze();
            dialogBox.SetText("");
            holder.SetActive(false);

            isCycle = false;
        }
    }

    public void PressOk()
    {
        ok = true;
    }
}
