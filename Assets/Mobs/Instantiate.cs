using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instantiate : MonoBehaviour {
    
    public Player ip;
    public Wumpus iw;
    bool wspawn;

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
        Instantiate(pfab, new Vector3(0,0,2),  Quaternion.identity);
        wspawn = true;
    }
    public void batinit(GameObject pfab)
    {
        //Instantiate(wumpusPB);
        Instantiate(pfab);

    }
    public void holeinit(GameObject pfab)
    {
        //Instantiate(wumpusPB);
        Instantiate(Resources.Load("WumpusPFB"));

    }
}
