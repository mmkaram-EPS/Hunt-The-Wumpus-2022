using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TriviaManager triviaManager;
    public GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void purchaseArrows()
    {
        StartCoroutine(triviaManager.Load(2, 3, success =>
        {
            // Then get an arrow
            manager.arrowCount++;
        }));
    }
}
    
public abstract class Item 
    {
      
    }

public class Arrows : Item 
    {
        public int cost = 100;
    }

public class WumpusLocation : Item 
    {

    }

public class Hints : Item 
    {

    }