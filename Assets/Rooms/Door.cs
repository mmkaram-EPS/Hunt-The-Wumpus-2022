using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string playerTag = "Player";
    public GameObject doorUIPanel;

    public RoomGen roomLoader;
    public int roomConnectedTo;

    private bool canPressE = false;

    void Awake()
    {
        doorUIPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == playerTag)
        {
            doorUIPanel.SetActive(true);
            canPressE = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == playerTag)
        {
            doorUIPanel.SetActive(false);
            canPressE = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canPressE && Input.GetKeyDown(KeyCode.E))
        {
            roomLoader.LoadRoom(roomConnectedTo);
        }
    }
}
