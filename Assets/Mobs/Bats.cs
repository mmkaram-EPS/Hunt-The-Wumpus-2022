using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

//i sorta need angads script to rlly do anything so
public class Bats : Mobs{

public Player ps;

public GameObject batPB;
RoomGen rg;
Room batLoc;
public GameObject[] objs;
public bool bat1Spawned;
public bool bat2Spawned;
public int batNo;
//assigning this object a room
public Bats(){

}

public override void whenPlayer(Player p){
    Debug.Log("player sensed");
    if (this.batNo == 1){
        bat1Spawned = false;
        move();
    }
    if (this.batNo == 2){
        bat2Spawned = false;
        move();
    }
    /* 
    animate();
    Destroy(batPB)
    playerRoom = rg.rooms[Random.Range(1,30)];
    batLoc = rg.rooms[Random.Range(1,30)]
}
public override void animate(){
    //wildly flails around 
}
*/
}
public void Start(){
    //init();
    //so rn initializing the bat within this script is generating infinte clones of the bat
    //so im thinking just run this function with the room generation
    //putting the initialization in the construction is throwing an error for some reason
    //so this was my fix
    foreach (GameObject go in objs){
        if (((!GameObject.FindGameObjectWithTag("Mobs")) && (bat1Spawned = false))){
            //init(); going to rework initializing to a random room
            bat1Spawned = true;
        }
        if ((!GameObject.FindGameObjectWithTag("Mobs")) && (bat1Spawned = true) && (bat2Spawned = false)){
            //init();
            bat2Spawned = true;
        }
        else{

        }
    }


}

public override void init(Room r){
    //inst prefab
   // Debug.Log(batPB);
    Instantiate(batPB);
    batLoc = r;
}

public override void move(){
    for (int i = 0; i < rg.rooms.Length; i++){
        if (GameObject.Find("Bat") != null){
        }
        else{
            if (bat1Spawned = false){
                if (this.batNo == 1){
                    Destroy(this.batPB); //HOPEFULLY this doesn't destroy my variable and just the attatched game object (im not super familiar w destroy)
                   // this.batLoc = rg.rooms[Random.Range(1,30)]; reworking spawning system
                }
            }
            if (bat2Spawned = false){
                if (this.batNo == 2){
                    Destroy(this.batPB);
                   // this.batLoc = rg.rooms[Random.Range(1,30)];
                }
            }


                  
               }
               }
}
    public override void animate()
    {
        throw new System.NotImplementedException();
    }

}