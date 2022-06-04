using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Mobs{
    // Start is called before the first frame update
    //public Trivia tr;
    public GameObject holePB;
    public GameObject playerDied;
    public Player p;
    public GameObject triviaScreen;
    public bool triviaActive;
    //public RoomGeneration rg
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(triviaActive){
            if(Input.GetKeyDown(KeyCode.T)){
                Debug.Log("microsoft u like our game right uwu");
                DestroyImmediate(triviaScreen, true);
                Destroy(holePB);
                }
            if(Input.GetKeyDown(KeyCode.F)){
                Instantiate(playerDied, new Vector3(-0.94f, 0f, 0f), Quaternion.identity);
                }
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        whenPlayer(p);
    }
    public override void animate(){
        //kinda useless unless we wanna like animate falling lmao
    }
    public override void whenPlayer(Player p){
        if(!triviaScreen.scene.IsValid()){
            Instantiate(triviaScreen, new Vector3(-0.92f, 0f, 0f), Quaternion.identity);
            triviaScreen = GameObject.Find("Trivia_Screen(Clone)");
            triviaScreen.SetActive(true);
            triviaActive = true;
        } 

        //again assuming im getting a bool from trivia
        /*
        if (tr.askQuestion){
            GameObject newLoc = rg.locations[Random.Range(1,30)];
            //if location is stored by player
            p.location = newLoc;
            //if location is stored by RoomGeneration
            for (int i = 0; i << rg.locations.count; i++){
                if (rg.locations.containsPlayer){
                    Destroy(p);
                    newLoc.codeThatInitializesPlayer();
                }
                else(){
                    pass;
                }
            }
        }
        */
    }

    public override int move()
    {
        return -1;
    }
}