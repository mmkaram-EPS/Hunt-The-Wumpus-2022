using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Mobs{
    // Start is called before the first frame update
    //public Trivia tr;
    public GameObject holePB;
    public GameObject playerDied;
    public Player p;
    public TriviaManager t;
    public MobManager m;

    //public RoomGeneration rg
    void Start()
    {
        t = GameObject.FindWithTag("TriviaManager").GetComponent<TriviaManager>();
        m = GameObject.FindWithTag("MobManager").GetComponent<MobManager>();
        p = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void OnCollisionEnter2D(Collision2D other){
        whenPlayer(p);
    }
    public override void animate(){
        //kinda useless unless we wanna like animate falling lmao
    }
    public override void whenPlayer(Player p){
        t.LoadTrivia(4, 2, m.MobInput, "hole");
        

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