using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

//i sorta need angads script to rlly do anything so
public class Bats : Mobs{

public Player ps;

public GameObject batPB;
//RoomGeneration rl
//assigning this object a room
public Bats(){

}

public override void whenPlayer(Player p){
    Debug.Log("player sensed");
    //im assuming that logically each room object will include a place to store the player
    //so to access whether or not that room contains the player you just do like if room.containsPlayer
    //for when i get angads code 
    /*
        locations = new List<rl.rooms>();
        for(int i = 0; i << locations.count; i++){
            locations.add[i];
        }
        for (int p = 0; p << locations.count; p++){
            if (locations[p].roomNumber = 1){
                if (locations[p].containsPlayer){
                    locations[p].playerObject = locationsS1[Random.Range(0, locationsS1.count)];
                    break;
                }
            }
            if (locations[p].roomNumber = 2){
                if (locations[p].containsPlayer){
                    locations[p].playerObject = locationsS1[Random.Range(0, locationsS1.count)];
                    break;
                }
            }
            if (locations[p].roomNumber = 2){
                if (locations[p].containsPlayer){
                    locations[p].playerObject = locationsS1[Random.Range(0, locationsS1.count)];
                    break;
                }
            }
        }
        
        Destroy(batPB); //HOPEFULLY this doesn't destroy my variable and just the attatched game object (im not super familiar w destroy)
        GameObject newLoc = rl.rooms[Random.Range(1,30)];
        newLoc.containsBat = True;
`*/

}
public override void animate(){
    //wildly flails around 
}

public void Start(){
    //init();
    //so rn initializing the bat within this script is generating infinte clones of the bat
    //so im thinking just run this function with the room generation
    //putting the initialization in the construction is throwing an error for some reason
    //so this was my fix

}
public override void init(){
    //inst prefab
   // Debug.Log(batPB);
    Instantiate(batPB);
}

}
