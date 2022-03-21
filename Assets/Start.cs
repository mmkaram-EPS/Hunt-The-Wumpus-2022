using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartScreen.setActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.getButtonDown(KeyCode.Return) && StartScreen.activeSelf)
        {
            StartScreen.setActive(false);
        }
    }
}
