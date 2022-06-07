using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{

    // Currently Opened Room
    public Room activeRoom;
    public GameObject roomObj;
    public Dialog dialog;
    public New_Trivia triviaData;

    // Room With Wumpus object
    // This is not working yet, need to still work with Julian


    // Prefab for rooms
    public GameObject[] rooms;

    public GameManager manager;

    // Type of map from 0 to 4, 5 types
    int mapType = 0;

    // Current Map
    Dictionary<int, int[]> activeMap()
    {
        if (mapType == 0)
        {
            return map1;
        }
        else if (mapType == 1)
        {
            return map2;
        }
        else if (mapType == 2)
        {
            return map3;
        }
        else if (mapType == 3)
        {
            return map4;
        }
        else if (mapType == 4)
        {
            return map5;
        }

        return null;
    }

    #region map_data
    // Dictionaries goes here
    Dictionary<int, int[]> map1 = new Dictionary<int, int[]>(){
        {0, new int[] { 2, 3, 4 } },
        {1, new int[] { 4, 5, 7 } },
        {2, new int[] { 0, 3, 4 } },
        {3, new int[] { 0, 2, 8 } },
        {4, new int[] { 1, 0, 2 } },
        {5, new int[] { 1, 6, 8 } },
        {6, new int[] { 7, 5, 9 } },
        {7, new int[] { 10, 1, 6 } },
        {8, new int[] { 3, 5, 10 } },
        {9, new int[] { 6, 10, 11 } },
        {10, new int[] { 1, 8, 9 } },
        {11, new int[] { 9, 13,12 } },
        {12, new int[] { 11, 13, 15 } },
        {13, new int[] { 11, 12, 17 } },
        {14, new int[] { 15, 17, 16 } },
        {15, new int[] { 12, 14, 19 } },
        {16, new int[] { 17, 14, 18 } },
        {17, new int[] { 13, 14, 16 } },
        {18, new int[] { 20, 19, 16 } },
        {19, new int[] { 15, 18, 20 } },
        {20, new int[] { 21, 19, 18 } },
        {21, new int[] { 22, 24, 20 } },
        {22, new int[] { 23, 25, 21 } },
        {23, new int[] { 26, 24, 22 } },
        {24, new int[] { 23, 25, 21 } },
        {25, new int[] { 26, 24, 22 } },
        {26, new int[] { 28, 23, 25 } },
        {27, new int[] { 28, 29 } },
        {28, new int[] { 26, 29, 27 } },
        {29, new int[] { 28, 27 } },
    };
    Dictionary<int, int[]> map2;
    Dictionary<int, int[]> map3;
    Dictionary<int, int[]> map4;
    Dictionary<int, int[]> map5;
    #endregion

    //Assigning room ID
    public int currentID = 0;

    bool hasStarted = false;

    // Start Function
    void Start()
    {
        LoadRoom(0);
        //mapType = Random.Range(0, 4);
        currentID = 0;
        mapType = 0;
    }

    public void LoadRoom(int roomToLoad)
    {
        currentID = roomToLoad;

        // Destroy Old Room
        if (roomObj != null)
        {
            Destroy(roomObj.transform.parent.gameObject);
        }

        if(hasStarted)
        {
            // Coin anim + Trivia here !!!!
            manager.turns++;
            dialog.StartText(new string[] { triviaData.RandomAnswer() });
        }

        hasStarted = true;

        // Get the child of the Instantiated object
        roomObj = Instantiate(rooms[roomToLoad]).transform.GetChild(0).gameObject;

        // Get the room child of the Instantiated object and store the Room class
        Room room = roomObj.GetComponent<Room>();
        // Setting the currently active room
        activeRoom = room;

        // If we haven't passed through the room, then give money
        if (!room.hasPassed)
        {
            manager.coins++;
            room.hasPassed = true;
        }

        // Assign the door connections based off of the dictionary
        activeRoom.door1.roomConnectedTo = activeMap()[roomToLoad][0];
        activeRoom.door2.roomConnectedTo = activeMap()[roomToLoad][1];
        activeRoom.door3.roomConnectedTo = activeMap()[roomToLoad][2];
    }

    // Gain information about the rooms
    #region access_the_rooms

    // Find the distance to a room x from y
    public int DistanceTo(int start, int end)
    {
        // Rooms that we have already finished
        ArrayList visited = new ArrayList();

        // To-do list for the algorithm
        ArrayList fringe = new ArrayList();

        // Add the start node
        fringe.Add(start);

        // Distance to the next node
        int distance = 0;

        // while we still have a to-do list
        while (fringe.Count != 0)
        {
            // Popping from fringe
            // We are taking the room object and removing it from the fringe
            int current = (int)fringe[0];

            // Remove the current state from the fringe
            fringe.Remove(current);

            // Add current to visited, prevent recursion
            visited.Add(current);

            // If we have reached our goal, return the distance
            if (current == end)
            {
                return distance;
            }

            // Increase the distance by one
            distance++;

            // Add the neighbors to the fringe
            foreach (int neighbor in activeMap()[current])
            {
                // If it is in fringe, do not add it
                if (!fringe.Contains(neighbor))
                {
                    // Add the neighbor
                    fringe.Add(neighbor);
                }
            }
        }
        return -1;
    }
    #endregion
}
