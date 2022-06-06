using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialogBox;
    public GameObject holder;
    public Player player;

    public void StartText(string input)
    {
        holder.SetActive(true);
        player.Freeze();
        StartCoroutine(LoadText(input));
    }

    IEnumerator LoadText(string input)
    {
        // Reset the Text
        dialogBox.SetText("");
        // Kinda Smooth Anim thing
        for (int i = 0; i < input.Length; i++)
        {
            dialogBox.text += input[i];
            yield return new WaitForSeconds(0.1f);
        }

        // Unfreeze the player, reset the dialog box, disable the UI
        player.Freeze();
        dialogBox.SetText("");
        holder.SetActive(false);
    }
}
