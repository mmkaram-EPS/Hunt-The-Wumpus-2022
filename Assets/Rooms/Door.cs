using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string playerTag = "Player";

    // Room Variables
    public RoomGen roomLoader;
    public int roomConnectedTo;

    // Door UI
    public Canvas doorCanvas;
    public GameObject doorUIPanel;

    private bool canPressE = false;

    void Awake()
    {
        // Set Room Loader (not in prefab)
        roomLoader = GameObject.FindWithTag("RoomMain").GetComponent<RoomGen>();

        // Set Main Camera on Canvas
        doorCanvas.worldCamera = Camera.main;

        // Disable the UI
        doorUIPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // If hit by player
        if (col.gameObject.tag == playerTag)
        {  
            // Show the UI
            doorUIPanel.SetActive(true);
            // Can Press E
            canPressE = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Opposite of on Trigger Enter
        if (col.gameObject.tag == playerTag)
        {
            doorUIPanel.SetActive(false);
            canPressE = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If they can press E and do
        if (canPressE && Input.GetKeyDown(KeyCode.E))
        {
            // Load the next room
            roomLoader.LoadRoom(roomConnectedTo);
        }
    }
}
