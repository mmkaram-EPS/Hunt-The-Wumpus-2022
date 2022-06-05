using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instantiate : MonoBehaviour {
    
    public Player ip;

    public void wumpinit(GameObject pfab)
    {
        Instantiate(pfab, new Vector3(0,0,2),  Quaternion.identity);
    }
    public void batinit(GameObject pfab)
    {
        Instantiate(pfab, new Vector3(0, 0, 2), Quaternion.identity);

    }
    public void holeinit(GameObject pfab)
    {
        Instantiate(pfab, new Vector3(0, 0, 2), Quaternion.identity);

    }
}
