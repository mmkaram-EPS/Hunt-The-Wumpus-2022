using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Mobs : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    abstract public void animate();
    abstract public void whenPlayer(Player p);

    abstract public void init();
    
}
