using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room : MonoBehaviour
{
    public Door door1;
    public Door door2;
    public Door door3;

    public ArrayList connected = new ArrayList();
    public int id;

}