using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSubtract : MonoBehaviour
{
    int coinAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()
    {
        coinAmount++;
        // Prints out the coin amount in the console
        Debug.Log(coinAmount);

    }
    public void SubtractCoins()
    {
        coinAmount--;
        // Prints out the coin amount in the console
        Debug.Log(coinAmount);
    }
}

