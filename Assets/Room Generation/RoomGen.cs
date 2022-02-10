using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{
    ArrayList notVisited = new ArrayList();
    ArrayList rooms = new ArrayList();
    //ArrayList roomsAsIntegers = new ArrayList();

    void Start()
    {
        RoomGenerate();
        Debug.Log(rooms.Count);
    }

    void RoomGenerate()
    {
        for (int i = 0; i < 30; i++)
        {
            rooms.Add(new Room(i));
            notVisited.Add(i);
            //roomsAsIntegers += i;
        }
        RoomConnect(rooms);
    }

    void RoomConnect(ArrayList arr)
    {
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
    }
}

