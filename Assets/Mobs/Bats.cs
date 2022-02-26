using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Bats : Mobs{
public Player ps;

//public Vector2 pl = ps.location; doesn't exist yet
public Vector2 pl; 
public GameObject batPB;
//RoomGeneration rl
public RoomGen rl;
//public Room r;
public RoomGen newLoc;
//assigning this object a room

public BoxCollider collider;

public void Start(){
        //checking for player in room
        if (collider.bounds.Contains(pl)){
            whenPlayer(ps);
        }
}
public override void whenPlayer(Player p){
    //test
    Debug.Log("player sensed");
    //new room 4 player
    //newLoc = rl.rooms[Random.Range(1,30)]; throwing implicit conversion error
    //stand in for moving player to new location
    //im assuming the actual code is gonna be instantiating a new room and deleting the old one
    //but that code isn't written yet so (?)
    //p.room = newLoc;
    //destroy and reinstantiate bat
    Destroy(batPB);
    Instantiate(batPB); //needs to be instantiated in new room
}
            
public override void animate(){
}
public override void init(){
    Instantiate(batPB);
}
}



