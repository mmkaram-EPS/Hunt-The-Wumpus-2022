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
    public GameObject wumpusUI;
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
    }
    wumpusUI = wumpusPB.transform.GetChild(0).gameObject;
    //wumpusUI = Instantiate(Resources.Load("Assets/Mobs/WumpusPFB/WumpUI")) as GameObject;
        
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
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player"){
            whenPlayer(wp);
        }
    }

    public override void whenPlayer(Player p){
        Debug.Log("JAN X WUMPUS");
        wumpusUI.SetActive(true);
        Debug.Log(wumpusUI.activeSelf);
        //for when trivia ready :D
        //tr.tooAnswer();
        /*if (!tr.toAnswerResult){
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
            
            Debug.Log("Die");
        }
        else{
            
        }*/
        Invoke("move", 2);
        
    }
    public override void animate()
    {

    }
    public override void move()
    {
        Destroy(wumpusPB);
        wumpusUI.SetActive(false);
        Debug.Log(wumpusUI.activeSelf);
        wumpSpawned = false;
        wumpLoc = rg.rooms[Random.Range(0,30)];//wait for angads updates to change into different location
    }
    
} 