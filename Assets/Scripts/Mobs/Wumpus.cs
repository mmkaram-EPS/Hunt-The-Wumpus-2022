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
    public TriviaInput tri;
    void Start()
    {
    foreach (GameObject go in objs){
        /*if (((GameObject.FindGameObjectWithTag("Mobs")) && (wumpSpawned = false))){
            init(wumpusLoc);
            wumpSpawned = true;
        }*/
        if (go.name == "WumpusPFB"){
            wumpSpawned = true;
        }
        wumpLoc = rg.rooms[Random.Range(0,29)];
        Debug.Log(wumpLoc);
        tempConversion = GameObject.FindGameObjectWithTag("Rooms");
    }
    //wumpusUI = Instantiate(Resources.Load("Assets/Mobs/WumpusPFB/WumpUI")) as GameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player"){
            whenPlayer(wp);
            move();
        }
    }
    public override void whenPlayer(Player p){
        tr.LoadTrivia(5, 3, tri, "wumpus");
        
    }
    public override void animate()
    {

    }
    public override int move()
    {
        //Destroy(tempConversion);
        Destroy(wumpusPB);
        wumpLoc = rg.rooms[Random.Range(0,29)];//wait for angads updates to change into different location

        return -1;
    }
    
} 