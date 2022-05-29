using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{

    // Currently Opened Room
    public GameObject activeRoom;

    // Room With Wumpus object
    // This is not working yet, need to still work with Julian
    

    // Prefab for rooms
    public GameObject[] rooms;

    public GameManager manager;

    // Start Function
    void Start()
    {
        LoadRoom(0);
    }

    public void LoadRoom(int roomToLoad)
    {
        GameObject roomObj = Instantiate(rooms[roomToLoad]);

        if (activeRoom != null)
        {
            Destroy(activeRoom);
        }

        activeRoom = roomObj;

        manager.turns++;
    }

    // Gain information about the rooms
    #region access_the_rooms

    // Find the distance to a room x from y
    public int DistanceTo(Room start, Room end)
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
            Room current = (Room)fringe[0];
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
            foreach (Room neighbor in current.connected)
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

