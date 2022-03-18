using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{

    ArrayList notVisited = new ArrayList();
    //needed this public for my code
    public ArrayList rooms = new ArrayList();

    public int roomWithWumpus;

    public GameObject roomPrefab;

    // Start Function
    void Start()
    {
        RoomGenerate();
    }

    // Create all of the rooms
    void RoomGenerate()
    {
        // For loop that loops through 30 rooms to create
        for (int i = 0; i < 30; i++)
        {
            // Instantiate the room prefab
            GameObject instance = Instantiate(roomPrefab);
            // Get the room class from the prefab
            Room instanceRoom = instance.GetComponent<Room>();
            // Add the room class to the list of rooms
            rooms.Add(instanceRoom);
            // Assign the Id to the room class
            instanceRoom.Create(i);

            //roomsAsIntegers += i;
        }

        // Call the method to connect the rooms
        RoomConnect((Room) rooms[0]);
    }

    // Connect the Rooms to each other, randomly
    void RoomConnect(Room start)
    {
        // Already assigned nodes
        ArrayList assigned = new ArrayList();
        
        // Not visited nodes
        ArrayList notVisited = rooms;

        // Fringe, helps us keep track of what we need to visit next
        ArrayList fringe = new ArrayList();

        // Add the start to the fringe
        fringe.Add(start);


        // While we still have not visited every room
        while (notVisited.Count != 0)
        {
            // Popping from fringe
            // We are taking the room object and removing it from the fringe
            Room current = (Room) fringe[fringe.Count - 1];

            // We must also remove the current room from the fringe
            fringe.Remove(current);

            // Because our Priority is to hit all thirty rooms, we have this notVisited ArrayList
            // In this ArrayList, we must remove the current room
            notVisited.Remove(current);

            Debug.Log(current.id);
            // Randomly select the neighboring nodes from notVisited list
            for (int i = 0; i < 3; i++)
            {
                // Pick a random room that has not been visited
                int randomRoomID = Random.Range(0, notVisited.Count - 1);

                Debug.Log(randomRoomID);
                Debug.Log(notVisited.Count);

                // Relate the id to the room object
                Room randomRoom = (Room)notVisited[randomRoomID];

                // If we have not visited the new neighbor, or we are not planning to, add it to the fringe
                // The fringe is kind of our to-do list
                if (!fringe.Contains(randomRoom) && !assigned.Contains(randomRoom))
                {
                    // Add the new neighbor to the fringe, so we can connect this to the rooms as well
                    fringe.Add(randomRoom);
                }

                // Add the new neighbor to the current room
                current.connected.Add(randomRoom);
            }

            // Add this room to the rooms that have been assigned
            assigned.Add(current);
        }
        Debug.Log("Done!");

        #region old_code
        /*if (id == 29)
        {
            return;
        }
        ArrayList roomsToConnect = new ArrayList();
        roomsToConnect.Add(prevRoom);
        if (visited.Count == 29)
        {
            for (int i = 0; i < 2; i++)
            {
                int connect = Random.Range(0, 29);
                roomsToConnect.Add(rooms[connect]);
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                int connect = Random.Range(0, 29);
                if (visited.Contains(connect) || room.id == connect)
                {
                    RoomConnect(room, prevRoom, id);
                    return;
                }
                visited.Add(connect);
                roomsToConnect.Add(rooms[connect]);
            }
        }
        room.Assign(roomsToConnect);
        RoomConnect((Room) rooms[id + 1], room, id + 1);

        string hi = "";
        for (int i = 0; i < roomsToConnect.Count; i++)
        {
            Room hie = (Room)roomsToConnect[i];
            hi += hie.id;
        }
        Debug.Log("Room " + id + "Connected: " + hi);*/
        #endregion
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

