using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Mobs{
    // Start is called before the first frame update
    //public Trivia tr;
    public GameObject holePB;
    //public RoomGeneration rg
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void animate(){
        //kinda useless unless we wanna like animate falling lmao
    }
    public override void whenPlayer(Player p){
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

    public override void move()
    {
        throw new System.NotImplementedException();
    }
}