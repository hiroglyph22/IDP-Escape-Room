using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHolder : MonoBehaviour
{

    private DialogueManager dM;

    public string[] dialogueLines = { "Welcome to 'The Mystery of the Mad Scientist'", "What is your username?", "Here we go!", "... ... ...",
        "You are an investigator on the search for the infamous Dr. Nefarious; a psychopathic scientist who has a gruesome " +
            "liking towards human behavior experiments through torture.", "Lucas: I’ve been looking for Dr. Nefarious for some " +
            "time now… I've finally found his laboratory and I need to catch him quickly.", "You arrive and step in front of the " +
            "door, something knocks you out and you lose consciousness. You wake up in a small room.", "Lucas: I’m dizzy and my mind" +
            " is all over the place. The last thing I remember is walking into the front of Dr. Nefarious’ laboratory.", "You look " +
            "around and notice a door. You drag yourself to the door, and as you try to open it, you find out it’s locked. A loud " +
            "voice booms from outside the door.", "Dr. Nefarious: Welcome detective! What I’ve set up is an escape room! You have 30 " +
            "minutes to solve the puzzles and escape this laboratory. I’ve left you with some clues to help you get out of this room, " +
            "but the rest is up to you. Your time starts now!" };

    // Start is called before the first frame update
    void Start()
    {
        dM = FindObjectOfType<DialogueManager>();

    }




}
