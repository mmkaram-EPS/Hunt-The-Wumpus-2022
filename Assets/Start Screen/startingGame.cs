using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingGame : MonoBehaviour
{
    public GameObject Exposition;
    public GameObject beginScreen;
    // Start is called before the first frame update
    void Start()
    {
        Exposition.SetActive(true);
        beginScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && beginScreen.activeSelf)
        {
            beginScreen.SetActive(false);
        } else if (Input.GetButtonDown("Submit"))
        {
            Exposition.SetActive(false);
        }
    }
}
