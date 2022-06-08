using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instantiate : MonoBehaviour {
    
    public Player ip;

    public GameObject wumpinit(GameObject pfab)
    {
        GameObject wump = Instantiate(pfab, new Vector3(0,0,2),  Quaternion.identity);
        wump.GetComponent<Wumpus>().tr = GameObject.FindWithTag("TriviaManager").GetComponent<TriviaManager>();
        wump.GetComponent<Wumpus>().m = GameObject.FindWithTag("MobManager").GetComponent<MobManager>();
        wump.GetComponent<Wumpus>().wp = GameObject.FindWithTag("Player").GetComponent<Player>();

        wump.GetComponent<Wumpus>().whenPlayer(wump.GetComponent<Wumpus>().wp);

        return wump;
    }
    public GameObject batinit(GameObject pfab)
    {
        GameObject bat = Instantiate(pfab, new Vector3(0, 0, 2), Quaternion.identity);
        bat.GetComponent<Bats>().roomLoader = GameObject.FindWithTag("RoomMain").GetComponent<RoomGen>();
        bat.GetComponent<Bats>().ps = GameObject.FindWithTag("Player").GetComponent<Player>();

        return bat;

    }
    public GameObject holeinit(GameObject pfab)
    {
        GameObject hole = Instantiate(pfab, new Vector3(0, 0, -1.5f), Quaternion.identity);
        hole.GetComponent<Hole>().t = GameObject.FindWithTag("TriviaManager").GetComponent<TriviaManager>();
        hole.GetComponent<Hole>().m = GameObject.FindWithTag("MobManager").GetComponent<MobManager>();
        hole.GetComponent<Hole>().p = ip;

        return hole;
    }
}
