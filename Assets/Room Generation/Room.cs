using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public ArrayList connected;
    public int id;
    public Room(int _id)
    {
        id = _id;
        Debug.Log(id);
    }

}