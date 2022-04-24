using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    coins = 100;
    ArrayList arrowArray = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void purchaseArrows(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Arrows arrow = new Arrows()
            arrowArray.Add(arrow);
            coins -= arrow.cost;
        }
    }
}
    
abstract class Item 
    {
      
    }

public class Arrows : Item 
    {
        static int cost = 100;
    }

public class WumpusLocation : Item 
    {

    }

public class Hints : Item 
    {

    }