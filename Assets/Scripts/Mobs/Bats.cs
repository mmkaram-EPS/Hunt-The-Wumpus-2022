using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

//i sorta need angads script to rlly do anything so
public class Bats : Mobs{

public Player ps;

public GameObject batPB;
GameObject batLoc1;
GameObject batLoc2;
public GameObject[] objs;
public bool bat1Spawned;
public bool bat2Spawned;
public int batNo;
public RoomGen rg;
//assigning this object a room
public Bats(){

}
private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.name == "Player"){
        whenPlayer(ps);
    }
}
public override void whenPlayer(Player p){
    move();
    if (!bat1Spawned){
        this.batNo = 1;
        bat1Spawned = true;
    }
    if ((bat1Spawned = true)&&(bat2Spawned=false)){
        this.batNo = 2;
        bat2Spawned = true;
    }
    /*if (this.batNo == 1){
        bat1Spawned = false;
        move();
        roomLoader.LoadRoom(rg.rooms[Random.Range(1,30)]);
    }
    if (this.batNo == 2){
        bat2Spawned = false;
        move();
        roomLoader.LoadRoom(rg.rooms[Random.Range(1,30)]);
    }*/
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
//    GameObject phder = GameObject.FindWithTag("playerTag");
    //ps = phder.GetComponent<Player>();
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


public override int move(){
    rg.LoadRoom(Random.Range(0,29));
    ps.Reset();
    Destroy(batPB);
    //this.SetActive(false);
   // Debug.Log(this.activeSelf);
    if (this.batNo == 1){
        bat1Spawned = false;
        batLoc1 = rg.rooms[Random.Range(0,29)];
    }
    if (this.batNo == 2){
        bat2Spawned = false;
        batLoc2 = rg.rooms[Random.Range(0,29)];
    }

        /*for (int i = 0; i < rg.rooms.Length; i++){
            if (GameObject.Find("Bat") != null){
            }
            else{
                if (bat1Spawned = false){
                    if (this.batNo == 1){
                        Destroy(this.batPB); //HOPEFULLY this doesn't destroy my variable and just the attatched game object (im not super familiar w destroy)
                       this.batLoc1 = rg.rooms[Random.Range(1,30)];
                    }
                }
                if (bat2Spawned = false){
                    if (this.batNo == 2){
                        Destroy(this.batPB);
                       this.batLoc2 = rg.rooms[Random.Range(1,30)];
                    }
                }



                   }
                   }
    }
        public override void animate()
        {
            throw new System.NotImplementedException();
        }*/

        return -1;

}
    public override void animate()
    {
        throw new System.NotImplementedException();
    }
}