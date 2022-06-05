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
    public TriviaInput ShopInput;
    public TriviaManager t;
    //public RoomGeneration rg
    void Start()
    {
        t = GetComponent<TriviaManager>();
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
        triviaActive = true;
        t.LoadTrivia(4, 2, ShopInput, "arrow");
        

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