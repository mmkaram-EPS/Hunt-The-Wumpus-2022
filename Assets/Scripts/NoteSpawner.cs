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
    public string noteTextSecret;
    public GameObject noteObj;
    public Text noteTextObj;
    public GameObject notePFB;
    public bool noteExists;
    public bool noteOnce;
    public int notesCollected;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++){
            freeRoom.Add(i);
        }
        for (int r = 0; r < 9; r++){
            randomRoom = Random.Range(1, freeRoom.Count);
            noteRooms.Add(randomRoom);
            freeRoom.Remove(randomRoom);
        }
        noteTexts.Add("You find a note. 'For the first time ever, it's Hunt the Wumpus IN REAL LIFE! Come see the first ever capture of a REAL Wumpus! Featuring the geniuses behind the effort, Cadence Ching, Jan Espelien, Mahdy Karam, Annika Chan, Seamus Fu, Angad Josan, Julian Yarkoni and-' The paper is torn to hide the note.");
        noteTexts.Add("Day 1, Log 1. Date, 5th of Febuary, 2011. Beginning of experiment. The Wumpus embreyo is stable. The faux host emulatir is keeping it well and alive. Features predicted to begin showing in around 1 week. Will update with any future info. Signing off, Jan Espelien.");
        noteTexts.Add("Day 5, Log 2. Date, 10th of Febuary, 2011. Wumpus showing unexpected development early on. Vitals are stable. Predicted to be ready for extraction from emulator week earlier than planned. Habitat preparations are being rushed because of this, but I have faith in Angad's team that he'll get it done soon. Will update with further news. Signing off, Jan Espelien");
        noteTexts.Add ("Documentation of construction permit issued to Seamus Fu. Date 16th April, 2011. Permits comstruction of: Wildlife habitat certified for single mammal under 3.5 meters, indoor plumbing system, outdoor plumbing system, electroshock therapy chamber, attatched observation chamber, single room veterinary facility. Address of building property: 14th Northup Road, ' The city and country have been scratched out.");
        noteTexts.Add("Day 25, Log 4. Date, March 2nd, 2011. Wumpus is showing extremely rapid devolpment, greater than we- really expected. Uh, im gonna be honest, I'm not sure if our habitat can actually hold it... accoriding to Seamus,  its gonna be like triple the size we expected. So... im hoping that we have the budget to house it. And also like... feed it... [yelling in background] what was that? Alright, I'll head over. This is Annika, signing off.");
        noteTexts.Add("You find a recorder and hit play.'You have 1 new message from Seamus Fu. [Beep] Hey... *noise cutting out* I just wanted to ask why you requested a... electroshock therapy chamber in our building permit? The thing is like, meant to be harmless so... theres no reason you'd need anything like that. But I wanted to hear you out before I tell the workers to stop construction and refile the permit. They're coming around May 14, so like a week from now, so if you get back to me before then I'll sort it out. Anyways, call me back when you get a chance.' The log ends.");
        noteTexts.Add("You find a recorder and hit play. 'Hello everyone, this is Julian, resident handler, and this-' You hear the sound of shuffling in the background-' Is the- hey, [laughing] get off me! The first ever Wumpus. And, as of June uh, what day is it? The 11th? June 11th, 2011, the first ever artificially created organism to be fully self sufficent.' More shuffling noises. 'What a cutie! Take a look at it. I think im gonna name it... Maid! What?' The audo goes quiet. You can make out people talking, but not what they're saying. 'Its name is Wumpus? Thats an awful name. Its also probably, like, copywrighted. Anyways, the extraction from the biochamber was a total success. Like, literally no complications whatsoever. Although, Maid is gonna grow to be like, three times as big for some reason. Someone must have messed up the supliment dosages. Anyways, she's completely harmless, isn't she! [cooing noises heard from Wumpus] yes she is, yes she is!' The recording ends.");
        noteTexts.Add("Toxicology Report on Specimin 3214, issued and conducted by Cadence Ching. Date of Study: April 19th, 2011. Full report issued below. Trace samples of engysterone, lab-manufacted testosterone specific to the 3214's glans, and amonegustrine, a growth compound found in many species of squash. Full report: [The paper is worn and stained to incomprehensibility.] Additional notes: The only person who had access to some of this stuff was me and Riley. This and his request for the electroshock chamber is extremely odd. Im gonna ask Mahdy about it.");
        //gonna try to add additional formatting
        noteTexts.Add("Annika just up and dissapeared today. Which is... bad. Cause now we dont have anyone to feed Maid. I've been trying my best, but every time I go in she just gets angrier and louder. Shes like, 20 feet now. Its insane. Worse thing is, she keeps getting shocked by Riley for getting mad at me. Really its just, [sigh] its just making it worse. I don't know how we're gonna keep this up. Signing off, Julian Yarkoni, July 23rd.");
        noteTexts.Add("You have 1 new message. Hey Riley. I just wanted to update you. Julian is in critical condition as of July 30th in the hospital. 3214 is entirely out of control. We tried to contact you after it happened but since you've been MIA recently we... just decided to take matters into our own hands. Look man, at this point don't even bother coming back. Just fill out the paperwork I sent you and promise to keep quiet about this, ok? We're working on killing 3214 right now, so this whole mess will be over soon. Cadence is heading in now to try and- oh god. Whats happening? [Crash and screaming can be heard] Crap. Oh no [footsteps as though they running, suddenly cut of by a slam and the recording ends].");
        noteTextSecret = "Note 11: Science experiment leaves 1 dead, several injured. This morning, renowed animal researcher Julian Yarkoni, best known for his work with Stegostoma Fasciatum, was reported to have passed away in his sleep while in recovery at NorthWest hospital. He died of severe lacerations and head wounds from what appears to be a large mammal that was being tested inside the Lewellen Labs. No team members have offered any explanation for how or what caused Julian's death and simply remark that they offer sincere condolences to his family. Other team member, Cadence Ching, was also found dead due to severe wounds. Her body was discovered in the woods 40 feet from the lab missing an arm and coverved in severe flesh wounds. Her body appeared to be dragged, and the area is currently under heavy surveillance. Please report any strange lifeforms or activities you see nearby.";

    }

    // Update is called once per frame
    void Update()
    {
        foreach (int o in noteRooms){
            if (o == currentRoomID.currentID){
                //Instantiate(notePFB);
                noteOnce = true;
                LoadNotes(currentRoomID.currentID);
            }
    }
    if (Input.GetKeyDown(KeyCode.N)){
        testNote(currentRoomID.currentID);
    }
    LoadNotes(currentRoomID.currentID);
    if (noteExists){
            if (Input.GetKeyDown(KeyCode.R)){
                if (noteOnce){
                    noteOnce = false;
                    n.loadNotePublic(noteTexts[Random.Range(0,10)], noteObj, noteTextObj);
                    notesCollected += 1;
            }
            else{
                n.loadNotePublic(noteTexts[Random.Range(0,10)], noteObj, noteTextObj);
            }
        }

    }

}
public void LoadNotes(int roomID){
    //noteTextObj.text = " ";
        for (int g = 0; g < noteRooms.Count; g++){
            if (noteRooms[g] == roomID){
                if (!GameObject.Find("Notes(Clone)")){
                    Instantiate(notePFB);
                }
                
        }
        }
        noteExists = true;

    }
public void testNote(int roomID){
    n = Instantiate(notePFB).GetComponent<Notes>();
    noteTextObj.text = " ";
    n.loadNotePublic(noteTexts[Random.Range(0,10)], noteObj, noteTextObj);

}
}