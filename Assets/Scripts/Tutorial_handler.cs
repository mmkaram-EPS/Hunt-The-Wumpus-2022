using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Tutorial_handler : MonoBehaviour
{
    public Image tut1;
    public Image tut2;
    public TextMeshProUGUI t11;
    public TextMeshProUGUI t12;
    public TextMeshProUGUI t13;
    public TextMeshProUGUI t14;
    public TextMeshProUGUI t21;
    public TextMeshProUGUI t22;
    public TextMeshProUGUI t23;

    // Start is called before the first frame update
    void Start()
    {
        tut1.gameObject.SetActive(true);
        t11.gameObject.SetActive(true);
        t12.gameObject.SetActive(true);
        t13.gameObject.SetActive(true);
        t14.gameObject.SetActive(true);
        tut2.gameObject.SetActive(false);
        t21.gameObject.SetActive(false);
        t22.gameObject.SetActive(false);
        t23.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            tut1.gameObject.SetActive(false);
            t11.gameObject.SetActive(false);
            t12.gameObject.SetActive(false);
            t13.gameObject.SetActive(false);
            t14.gameObject.SetActive(false);
            tut2.gameObject.SetActive(true);
            t21.gameObject.SetActive(true);
            t22.gameObject.SetActive(true);
            t23.gameObject.SetActive(true);
        }
    }
    public void closeTutorial(){
        SceneManager.LoadScene("Start-Expo");
    }
}
