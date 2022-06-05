using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public string playerTag = "Player";

    // Room Variables
    public RoomGen roomLoader;
    public int roomConnectedTo;

    // Door UI
    public TextMeshProUGUI doorUIPanel;

    [SerializeField]
    private bool canPressE = false;

    void Start()
    {
        // Set Room Loader (not in prefab)
        roomLoader = GameObject.FindWithTag("RoomMain").GetComponent<RoomGen>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // If hit by player
        if (col.gameObject.tag == playerTag)
        {  
            // Can Press E
            canPressE = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Opposite of on Trigger Enter
        if (col.gameObject.tag == playerTag)
        {
            canPressE = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        doorUIPanel.SetText(roomConnectedTo.ToString());
        // If they can press E and do
        if (canPressE && Input.GetKey(KeyCode.E))
        {
            // Load the next room
            // Start Counting from 1
            roomLoader.LoadRoom(roomConnectedTo - 1);
            roomLoader.currentID = roomConnectedTo;

            GameObject player = GameObject.FindWithTag(playerTag);
            player.GetComponent<Player>().Reset();

            // Trigger some sort of fade animation in the future
        }
    }
}
