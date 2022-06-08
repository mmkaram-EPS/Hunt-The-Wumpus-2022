using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowShooter : MonoBehaviour
{
    public GameObject arrowUI;
    public GameObject shopUI;
    public MobManager mobManager;
    public RoomGen roomGen;
    public GameManager manager;

    public TextMeshProUGUI button1;
    public TextMeshProUGUI button2;
    public TextMeshProUGUI button3;

    void Start()
    {
        arrowUI.SetActive(false);
    }

    public void Shoot()
    {
        arrowUI.SetActive(true);
        shopUI.SetActive(false);
        Room room = roomGen.activeRoom;

        button1.text = (room.door1.roomConnectedTo + 1).ToString();
        button2.text = (room.door2.roomConnectedTo + 1).ToString();
        button3.text = (room.door3.roomConnectedTo + 1).ToString();
    }

    public void ShootArrow(TextMeshProUGUI textMesh)
    {
        if (mobManager.roomWithWumpus + 1 == int.Parse(textMesh.text))
        {
            manager.Win(true);
        }
        else
        {
            // Wumpus runs away
            mobManager.roomWithWumpus = mobManager.RoomsFarAway(1);
        }

        arrowUI.SetActive(false);
    }
}