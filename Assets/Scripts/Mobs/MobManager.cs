using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    public Instantiate instantiate;
    public RoomGen roomGen;

    public GameObject holePrefab;
    public int roomWithPit1;
    public int roomWithPit2;

    public GameObject batPrefab;
    public int roomWithBat1;
    public int roomWithBat2;

    public GameObject wumpusPrefab;
    public int roomWithWumpus;

    public GameObject currentRoomObj;
    public RoomGen currentRoomID;

    void Start()
    {
        PickEverythingRandomly();
    }
    void Update() {
        //currentRoomObj = GameObject.FindGameObjectWithTag("Rooms");
        //currentRoomID = currentRoomObj.GetComponent<Room>();
        //print(currentRoomID.currentID);


        LoadRoomMobs(currentRoomID.currentID);  
    }
    void PickEverythingRandomly()
    {
        // List of available rooms
        List<int> availableRooms = new List<int>();
        // Nothing in the first room allowed, we start at 1
        for (int i = 1; i < 29; i++)
        {
            availableRooms.Add(i);
        }

        int randomRoom = Random.Range(1, availableRooms.Count);

        // Add Pit 1
        roomWithPit1 = randomRoom;
        availableRooms.Remove(randomRoom);
        //Debug.Log("first pit, " + randomRoom);

        // Add Pit 2
        randomRoom = Random.Range(1, availableRooms.Count);
        roomWithPit2 = randomRoom;
        availableRooms.Remove(randomRoom);
        //Debug.Log("second pit, " + randomRoom);

        // Add Bat 1
        randomRoom = Random.Range(1, availableRooms.Count);
        roomWithBat1 = randomRoom;
        availableRooms.Remove(randomRoom);

        // Add Bat 2
        randomRoom = Random.Range(1, availableRooms.Count);
        roomWithBat2 = randomRoom;
        availableRooms.Remove(randomRoom);

        // Add Wumpus
        randomRoom = Random.Range(1, availableRooms.Count);
        roomWithWumpus = randomRoom;
        availableRooms.Remove(randomRoom);

    }

    public void LoadRoomMobs(int id)
    {
        // Pits
        if(roomWithPit1 == id)
        {
            if(GameObject.Find("Hole(Clone)") == null){
                instantiate.holeinit(holePrefab);
            }
        }
        else if (roomWithPit2 == id)
        {
            if (GameObject.Find("Hole(Clone)") == null)
            {
                instantiate.holeinit(holePrefab);
            }
        }
        // Bats
        else if (roomWithBat1 == id)
        {
            if (GameObject.Find("BatPFB(Clone)") == null)
            {
                instantiate.holeinit(holePrefab);
            }
        }
        else if (roomWithBat2 == id)
        {
            if (GameObject.Find("BatPFB(Clone)") == null)
            {
                instantiate.holeinit(holePrefab);
            }
        }
        // Wumpus
        else if (roomWithWumpus == id)
        {
            if (GameObject.Find("WumpusPFB(Clone)") == null)
            {
                instantiate.holeinit(holePrefab);
            }
        }
    }

    public void MobInput(bool correct, string type)
    {
        if (type == "hole")
        {
            Debug.Log("W");
        }
    }
}
