using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room : MonoBehaviour
{
    public ArrayList connected;
    public int id;
    public TMP_Text tmp;
    public void Create(int _id)
    {
        id = _id;
        tmp.text = _id.ToString();
    }

}