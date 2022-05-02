using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instantiate : MonoBehaviour {
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void wumpinit()
    {
        //Instantiate(wumpusPB);
        Instantiate(Resources.Load("WumpusPFB"));
        
    }
    public void batinit()
    {
        //Instantiate(wumpusPB);
        Instantiate(Resources.Load("BatPFB"));

    }
    public void holeinit()
    {
        //Instantiate(wumpusPB);
        Instantiate(Resources.Load("WumpusPFB"));

    }
}
