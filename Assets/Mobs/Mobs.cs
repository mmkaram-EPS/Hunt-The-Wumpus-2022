using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Mobs : MonoBehaviour
{
    void Start(){

    }
    void Update(){

    }
    abstract public void animate();
    abstract public void whenPlayer(Player p);
    abstract public void init(Room r);
    abstract public void move();
    }