using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDialogHolder : MonoBehaviour
{

    private GameDialogManager gDM;

    public string[] dialogLines = { "Lucas: Great. Not only do I have to capture Dr. Nefarious, but I also have to get out of his " +
            "ridiculous labyrinth unless I want to become another experiment!", "Before we start the game, a couple things to give you a better " +
            "understanding of how this game works.", "You can interact with objects with space bar, and this same dialogue box will pop up. Some of " +
            "them will just give you text, and others will allow you to type in an answer.", "You can also use hints as well, pressing 'h'.", 
        "Hints will automatically " +
            "take away 2 minutes of your time, and you can only use 1 per puzzle. Keep in mind that there are 3-4 puzzles in each room.", 
        "If you can't find the answer after the first " +
            "hint, you can go back to the hint and type 'yes' to the prompt asking if you want the answer. Answers will take 1 minute " +
            "off of your time.","The last thing is, you can open up the current decoding paper and take a look at the table or chart by pressing 'i'" +
            "whenever you aren't already interacting with another object.", 
        "Thank you for playing!" };

    // Start is called before the first frame update
    void Start()
    {
        gDM = FindObjectOfType<GameDialogManager>();
    }
}
