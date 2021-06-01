using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1DoorScript : DefaultInteractableScript
{

    public GameObject door;
    public bool doorActive = false;
    public GameObject blackPanel;
    private Timer timer;
    static public int Room1RawTime;

    public void DoInteraction()
    {
        if (doorActive)
        {
            Room1RawTime = 1800 - Mathf.RoundToInt(Timer.time);
            gM.roomNum = 2;
            gM.hintNum = 3;
            blackPanel.SetActive(true);
        }
        else
        {
            gDM.ShowDialogue(new string[] { "Lucas: Man! Of course it’s locked. ", "To open the door, you must need a key to unlock.",
                "Lucas: So, I need a key then..." }, door);
        }
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }

}
