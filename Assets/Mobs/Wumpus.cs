using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wumpus : Mobs
{
    //RoomGeneration room;
    // Start is called before the first frame update
    public GameObject wumpusPB;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void whenPlayer(Player p){
        //activate trivia
        //im assuming that the function will return a true or false based on persons answer?
        //so
        /*if (Trivia.askQuestion){
            //switch scenes to death scene
        }
        else(){
            this.room = random room
        }
        */
    }
    public override void animate()
    {

    }
    public override void init()
    {
        Instantiate(wumpusPB);
    }
}
