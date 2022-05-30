using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 0 coins at the start, 100 to collect
    public int coins = 0;
    // 0 turns at the start
    public int turns = 0;
    // Three arrows by default
    public int arrowCount = 3;
    // Secrets start at 0
    public int secretCount = 0;
}
