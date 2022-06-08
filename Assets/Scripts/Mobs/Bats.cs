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
        whenPlayer(ps);
    }
}
public override void whenPlayer(Player p){
    Invoke("move", 3.0f);
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
    roomLoader = GameObject.Find("RoomLoader").GetComponent<RoomGen>();

}


public override int move(){
    ps.Reset();
    newroom = Random.Range(0,29);
    roomLoader.gameObject.SetActive(true);
    roomLoader.LoadRoom(newroom);
    Destroy(batPB);
    if (this.batNo == 1){
        bat1Spawned = false;
        batLoc1 = rg.rooms[Random.Range(0,29)];
    }
    if (this.batNo == 2){
        bat2Spawned = false;
        batLoc2 = rg.rooms[Random.Range(0,29)];
    }

        Debug.Log("I have moved");
    return -1;
}
    public override void animate()
    {
        throw new System.NotImplementedException();
    }
}
