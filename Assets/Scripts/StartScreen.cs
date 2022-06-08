using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreen : MonoBehaviour
{
    public GameObject start;
    public GameObject expo;
    public TextMeshProUGUI expoTextObj;

    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        expo.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (started)
            {
                SceneManager.LoadScene("Base Room");
                return;
            }
            StartCoroutine("loadStart");
            started = true;
        }
    }

    IEnumerator loadStart()
    {
        start.SetActive(false);

        string expoText = "In 2011, a team participating in \"Hunt the Wumpus\" chose to create a real life Wumpus and send the player into a real game of \"catch the Wumpus.\" However, they greatly underestimated the power of the Wumpus. It broke free of its confines and fled to an abandoned arcade. 10 years later with no news, you decide to investigate the scene of the crime . . .";
        expo.SetActive(true);

        expoTextObj.text = "";
        for (int i = 0; i < expoText.Length; i++)
        {
            expoTextObj.text += expoText[i];
            yield return new WaitForSeconds(0.05f);

            if (expoText[i] == ' ')
            {
                yield return new WaitForSeconds(0.02f);
            }
        }

        yield return new WaitForSeconds(5f);

        expo.SetActive(false);
        SceneManager.LoadScene("Base Room");
    }
}