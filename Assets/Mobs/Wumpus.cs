using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wumpus : Mobs
{
    //RoomGeneration room;
    // Start is called before the first frame update
    public GameObject wumpusPB;
    //public RoomGeneration rg
    //public Trivia tr
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
        /*if (!tr.askQuestion){
            //switch scenes to death scene
        }
        else(){
            this.move();
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
    public void move()
    {
        /*
           for (int i = 0; i < rg.rooms.count; i++){
               wumpsLoc = rg.rooms[i].GameObject.Find("Wumpus"); //I have no idea if this will work cause im thinking its gonna throw the null before I can pass but we'll see
               if (wumpsLoc == Null){
                   pass;
               }
               else{
                   Destroy(wumpusPB); //HOPEFULLY this doesn't destroy my variable and just the attatched game object (im not super familiar w destroy)
                   GameObject newLoc = rg.rooms[Random.Range(1,30)];
                   newLoc.containsWumpus = True;
                        //After this I assume we can just put some code in the rg file like
                        //run it in update
                        //if (this.containsWumpus){
                            //Wumpus.init();
                        //} 
                        //idrk
                  
               }
               }
           } 

        */
    }
}
