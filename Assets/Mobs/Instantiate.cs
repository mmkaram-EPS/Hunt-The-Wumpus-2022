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
    public void wumpinit(GameObject pfab)
    {
        //Instantiate(wumpusPB);
        Instantiate(pfab);
    }
    public void batinit(GameObject pfab)
    {
        //Instantiate(wumpusPB);
        Instantiate(Resources.Load("BatPFB"));

    }
    public void holeinit(GameObject pfab)
    {
        //Instantiate(wumpusPB);
        Instantiate(Resources.Load("WumpusPFB"));

    }
}
