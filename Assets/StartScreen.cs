using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject start;
    public GameObject expo;
    // Start is called before the first frame update
    void Start()
    {
        expo.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            start.SetActive(false);
            expo.SetActive(true);
            Invoke("loadStart", 3);
    }
    
}

public void loadStart()
{
    SceneManager.LoadScene("Base Room",  LoadSceneMode.Additive);
    expo.SetActive(false);
}
}