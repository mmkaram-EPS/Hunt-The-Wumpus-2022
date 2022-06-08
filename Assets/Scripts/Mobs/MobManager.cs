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

    public GameManager gm;

    public Dialog d;

    public Player p;
    public bool boxNoRun;
    public int rnCurrentRoom;

    void Start()
    {
        PickEverythingRandomly();
    }
    void Update() {
        //currentRoomObj = GameObject.FindGameObjectWithTag("Rooms");
        //currentRoomID = currentRoomObj.GetComponent<Room>();
        //print(currentRoomID.currentID);


        LoadRoomMobs(currentRoomID.currentID);
        CheckNearby();
    }

    void CheckNearby()
    {
        List<string> hazards = new List<string>();
        if (roomGen.DistanceTo(roomGen.currentID, roomWithPit1) <= 2)
        {
            hazards.Add("I feel a draft.");
        }
        if (roomGen.DistanceTo(roomGen.currentID, roomWithPit2) <= 2)
        {
            hazards.Add("I feel a draft.");
        }
        if (roomGen.DistanceTo(roomGen.currentID, roomWithBat1) <= 2)
        {
            hazards.Add("Bats Nearby");
        }
        if (roomGen.DistanceTo(roomGen.currentID, roomWithBat2) <= 2)
        {
            hazards.Add("Bats Nearby");
        }
        if (roomGen.DistanceTo(roomGen.currentID, roomWithWumpus) <= 2)
        {
            hazards.Add("I smell a Wumpus!");
        }

        Hazard(hazards.ToArray());
    }

    void Hazard(string[] input)
    {
        if (boxNoRun){
            d.StartText(input);
            rnCurrentRoom = currentRoomID.currentID;
            boxNoRun = false;
        }
        if (rnCurrentRoom != currentRoomID.currentID){
            boxNoRun = true;
        }


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
        Debug.Log("first pit, " + randomRoom);

        // Add Pit 2
        randomRoom = Random.Range(1, availableRooms.Count);
        roomWithPit2 = randomRoom;
        availableRooms.Remove(randomRoom);
        Debug.Log("second pit, " + randomRoom);

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

    public Mobs holeSpawned;
    public Mobs batSpawned;
    public Mobs wumpSpawned;

    public void LoadRoomMobs(int id)
    {
        // Pits
        if(roomWithPit1 == id)
        {
            if (holeSpawned == null)
            {
                holeSpawned = (Mobs)instantiate.holeinit(holePrefab).GetComponent<Hole>();
            }
        }
        else if (roomWithPit2 == id)
        {
            if (holeSpawned == null)
            {
                holeSpawned = (Mobs)instantiate.holeinit(holePrefab).GetComponent<Hole>();
            }
        }
        // Bats
        else if (roomWithBat1 == id)
        {
            if (batSpawned == null)
            {
                batSpawned = (Mobs)instantiate.batinit(batPrefab).GetComponent<Bats>();
            }
        }
        else if (roomWithBat2 == id)
        {
            if (batSpawned == null)
            {
                batSpawned = (Mobs)instantiate.batinit(batPrefab).GetComponent<Bats>();
            }
        }
        // Wumpus
        else if (roomWithWumpus == id)
        {
            wumpSpawned = (Mobs) instantiate.wumpinit(wumpusPrefab).GetComponent<Wumpus>();
        }
    }

    public void MobInput(bool correct, string type)
    {
        Debug.Log(correct);
        if (type == "hole" && correct)
        {
            Destroy(GameObject.Find("Hole(Clone)"));
            roomGen.LoadRoom(0);
            p.Reset();
        }
        else if (type == "hole" && !correct)
        {
            gm.Lose();
        }
        else if (type == "wumpus" && correct)
        {
            // Don't win here anymore, wumpus runs away
            roomWithWumpus = RoomsFarAway(Random.Range(2, 4));
        }
        else if (type == "wumpus" && !correct)
        {
            gm.Lose();
        }
    }

    public int RoomsFarAway(int distance)
    {
        int id = roomGen.currentID;
        for (int i = 0; i < distance - 1; i++)
        {
            // Pick a random one of the rooms, 
            id = roomGen.activeMap()[id][Random.Range(0, 2)];
        }

        return id;
    }
}
