using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

//i sorta need angads script to rlly do anything so
public class Bats : Mobs{

public Player ps;

public GameObject batPB;
RoomGen rg;
GameObject batLoc1;
GameObject batLoc2;
public GameObject[] objs;
public bool bat1Spawned;
public bool bat2Spawned;
public int batNo;
public RoomGen roomLoader;
public int newroom;
public GameObject phroom;
//assigning this object a room
private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.name == "Player"){
        move();
    }
}
public override void whenPlayer(Player p){
    move();
}


public void Start(){
    foreach (GameObject go in objs){
        if (((!GameObject.FindGameObjectWithTag("Mobs")) && (bat1Spawned = false))){
            bat1Spawned = true;
        }
        if ((!GameObject.FindGameObjectWithTag("Mobs")) && (bat1Spawned = true) && (bat2Spawned = false)){
            bat2Spawned = true;
        }
    }
    phroom = GameObject.FindGameObjectWithTag("Rooms");


}


public override int move(){
    //Destroy(phroom); incase room still isnt deleting on spawn
    newroom = Random.Range(0,29);
    //roomLoader.activeRoom = roomLoader.rooms[newroom];
    roomLoader.LoadRoom(newroom);
    ps.Reset();
    Destroy(batPB);
    if (this.batNo == 1){
        bat1Spawned = false;
        batLoc1 = rg.rooms[Random.Range(0,29)];
    }
    if (this.batNo == 2){
        bat2Spawned = false;
        batLoc2 = rg.rooms[Random.Range(0,29)];
    }
    return -1;
}
    public override void animate()
    {
        throw new System.NotImplementedException();
    }
}
