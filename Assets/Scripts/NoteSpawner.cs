using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSpawner : MonoBehaviour
{
    public List<int> noteRooms;
    public List<int> freeRoom = new List<int>();
    public RoomGen currentRoomID;
    public int randomRoom;
    public Notes n;
    public List<string> noteTexts;
    public GameObject noteObj;
    public Text noteTextObj;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++){
            freeRoom.Add(i);
        }
        for (int r = 0; r < 11; r++){
            randomRoom = Random.Range(1, freeRoom.Count);
            if (!freeRoom.Contains(randomRoom)){
                noteRooms[r] = randomRoom;
                freeRoom.Remove(randomRoom);
            }
        }
        noteTexts[0] = "You find a note. 'For the first time ever, it's Hunt the wumpus IN REAL LIFE! Come see the first ever capture of a REAL Wumpus! Featuring the geniuses behind the effort, Cadence Ching, Jan Espelien, Mahdy Karam, Annika Chan, Seamus Fu, Angad Josan, Julian Yarkoni and-' The paper is torn to hide the note.";
        noteTexts[1] = "Day 1, Log 1. Date, 5th of Febuary, 2011. Beginning of experiment. The Wumpus embreyo is stable. The faux host emulatir is keeping it well and alive. Features predicted to begin showing in around 1 week. Will update with any future info. Signing off, Jan Espelien.";
        noteTexts[2] = "Day 5, Log 2. Date, 10th of Febuary, 2011. Wumpus showing unexpected development early on. Vitals are stable. Predicted to be ready for extraction from emulator week earlier than planned. Habitat preparations are being rushed because of this, but I have faith in Angad's team that he'll get it done soon. Will update with further news. Signing off, Jan Espelien";
        noteTexts[3] = "Documentation of construction permit issued to Seamus Fu. Date 16th April, 2011. Permits comstruction of: Wildlife habitat certified for single mammal under 3.5 meters, indoor plumbing system, outdoor plumbing system, electroshock therapy chamber, attatched observation chamber, single room veterinary facility. Address of building property: 14th Northup Road, ' The city and country have been scratched out.";
        noteTexts[5] = " ";
        noteTexts[6] = " ";
        noteTexts[7] = " ";
        noteTexts[8] = " ";
        noteTexts[9] = " ";
        noteTexts[10] = " ";
        noteTexts[11] = " ";

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNotes(int roomID){
        noteTextObj.text = " ";
        for (int g = 0; g < noteRooms.Count; g++){
            if (noteRooms[g] == roomID){
            n.loadNotePublic(noteTexts[g], noteObj, noteTextObj);
        }
        }
    }

}
