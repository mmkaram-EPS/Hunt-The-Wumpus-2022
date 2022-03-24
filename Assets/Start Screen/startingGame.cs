using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingGame : MonoBehaviour
{
    public GameObject Exposition;
    public GameObject IntroText;
    public GameObject beginScreen;
    // Start is called before the first frame update
    void Start()
    {
        Exposition.SetActive(true);
        IntroText.SetActive(false);
        beginScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && beginScreen.activeSelf)
        {
            beginScreen.SetActive(false);
            beginScreen.SetActive(true);
        } else if (Input.GetButtonDown("Submit"))
        {
            Exposition.SetActive(false);
        }
    }
}
