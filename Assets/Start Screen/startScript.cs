using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour
{
    public GameObject Exposition;
    public GameObject IntroText;
    public GameObject BeginScreen;
    // Start is called before the first frame update
    void Start()
    {
        Exposition.SetActive(true);
        IntroText.SetActive(false);
        BeginScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && BeginScreen.activeSelf) 
        {
            BeginScreen.SetActive(false);
            IntroText.SetActive(true);
        } else if (Input.GetButtonDown("Submit"))
        {
            Exposition.SetActive(false);
            //roomLoader();
        }
    }
}
