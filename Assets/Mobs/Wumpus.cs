using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wumpus : Mobs
{
    //RoomGeneration room;
    // Start is called before the first frame update
    public GameObject wumpusPB;
    public RoomGen rg;
    public Trivia tr;
    public GameObject ph; 

    public GameObject[] objs;

    public bool wumpSpawned;

    Room wumpusLoc;
    public GameObject tempConversion;
    public Player p;
    public GameObject wumpusUI;
    void Start()
    {
    wumpusPB.SetActive(false);   
    foreach (GameObject go in objs){
        /*if (((GameObject.FindGameObjectWithTag("Mobs")) && (wumpSpawned = false))){
            init(wumpusLoc);
            wumpSpawned = true;
        }*/
        if (go.name == "WumpusPFB"){
            wumpSpawned = true;
        }
    }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void forceSpawn(){
        wumpusPB.SetActive(true);
    }
    public void forceUISpawn(){
        wumpusUI.SetActive(true);
    }


    public override void whenPlayer(Player p){
        wumpusUI.SetActive(true);
        if (!tr.toAnswer()){
            //switch scenes to death scene via destroying all the rooms and other spawned game objects (excluding start and lore screen) to reset the game
            /*
            for (int p = 0; p < rg.rooms.count; p++){
                Destroy(rg.rooms[i]);
                }
            foreach (GameObject o in objs){
            for (int u = 0; u < 50; u++){ 
            ph = GameObject.FindGameObjectWithTags(GameIntro)
            if (ph != null){
                pass;
                }
            }
            else{
                Destroy(objs[u]);
                            }
            }
            Instantiate(DeathCanvas) //should include buttons for retry and everything
            */
            Debug.Log("Die");
        }
        else{
            move();
        }
        
    }
    public override void animate()
    {

    }
    public override void init(Room r)
    {
        Instantiate(wumpusPB);
        wumpusLoc = r;

    }
    public override void move()
    {
        Destroy(wumpusPB);
        wumpSpawned = false;
        Debug.Log(rg.rooms[Random.Range(0,30)]);//wait for angads updates to change into different location
    }
    
} 