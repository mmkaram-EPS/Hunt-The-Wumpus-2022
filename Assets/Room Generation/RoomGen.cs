using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    ArrayList visited = new ArrayList();
    ArrayList rooms = new ArrayList();
    //ArrayList roomsAsIntegers = new ArrayList();

    void RoomGen()
    {
        for (int i = 0; i < 30; i++)
        {
            rooms.Add(new Room(i));
            //roomsAsIntegers += i;
        }
    }

    void RoomConnect(Room room)
    {
        if (visited.Count == 30)
        {
            return;
        }
        for (int i = 0; i < 3; i++)
        {
            int connect = Random.Range(1, 30);
            if (visited.Contains(connect) || room.id = connect)
            {
                RoomConnect(room);
                return;
            }
            visited.Add(connect);
        }
    }
}

public class Room
{
    int[] connected;
    public int id;
    public Room(int _id)
    {
        id = _id;
        Console.WriteLine(id);
    }
    public void Assign(int[] _connected)
    {
        connected = _connected;
    }
}