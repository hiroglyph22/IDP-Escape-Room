using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDialogHolder : MonoBehaviour
{

    public GameDialogManager gDM;

    public string[] dialogLines = { "Lucas: Great. Not only do I have to capture Dr. Nefarious, but I also have to get out of his " +
            "ridiculous labyrinth unless I want to become another experiment!", "You start searching the room for clues. You notice " +
            "a chest, which is settled next to your bed. You go straight to the chest, only to find out there is a combination lock " +
            "with the alphabet. You give the chest a shake.", "Lucas: I hear something rattling inside. It sounds like a key! Lets see " +
            "if I can open it.", "It seems that the chest has been closed off by a combination lock. Continue to look around the " +
            "room and gather clues to unlock this chest.", "Before we start the game, a couple things to give you a better " +
            "understanding of how this game works.", "You can interact with objects, and this same dialogue box will pop up. Some of " +
            "them will just give you text, and others will allow you to type in an answer.", "You can also use hints as well.", "Hints " +
            "take away 2 minutes of your time, and you can only use 1 per puzzle. Keep in mind that there are 3 puzzles in each room.", 
        "If you can't find the answer after the first " +
            "hint, you can go back to the hint and type 'yes' to the prompt asking if you want the answer. Answers will take 1 minute " +
            "off of your time.", "Thank you for playing!" };

    // Start is called before the first frame update
    void Start()
    {
        gDM = FindObjectOfType<GameDialogManager>();
    }
}
