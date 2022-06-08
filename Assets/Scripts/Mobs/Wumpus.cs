using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wumpus : Mobs
{
    //RoomGeneration room;
    // Start is called before the first frame update
    public GameObject wumpusPB;
    public RoomGen rg;
    public GameObject ph; 

    public GameObject[] objs;

    public bool wumpSpawned;

    public GameObject wumpLoc;
    public GameObject tempConversion;
    public Player wp;
    public TriviaManager tr;
    public MobManager m;


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player"){
            whenPlayer(wp);
        }
    }
    public override void whenPlayer(Player wp){
        tr.LoadTrivia(5, 3, m.MobInput, "wumpus");        
    }
    public override void animate()
    {

    }
    public override int move()
    {
        //Destroy(tempConversion);
        m.roomWithWumpus = m.RoomsFarAway(Random.Range(2, 4));
        Destroy(wumpusPB);

        return -1;
    }
    
} 