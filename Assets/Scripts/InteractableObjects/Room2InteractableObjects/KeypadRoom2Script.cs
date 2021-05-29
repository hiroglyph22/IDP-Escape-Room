using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadRoom2Script : InputInteractableScript
{

    public GameObject keypad;
    public GameObject blackPanel;
    static public int Room2RawTime;
    //The code is 581301134181981301981413
    public void DoInteraction()
    {
        if (timesInteracted == 1)
        {
            gDM.ShowDialogue(new string[] { "This is the keypad in which you must input a code to escape this room. It is a typical " +
            "keypad where you punch in the code.", "Lucas: What could the code be?" }, keypad);
        }
        else if (timesInteracted == 2)
        {
            gDM.ShowDialogue(new string[] { "Lucas: Lets see if I can unlock the keypad..." }, keypad);
            inputField.SetActive(true);
            access = true;
        }
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
        if (timesInteracted == 1)
        {
            timesInteracted = 2;
        }
        else if (timesInteracted == 2 && access)
        {
            if (input.text == "581301134181981301981413")
            {
                gM.hintNum = 6;
                gDM.InteractionAfterInput(new string[] {"Beep beep. The keypad turns green.", "Lucas: Yes! Looks like I got the " +
                    "answer! Man that was a long code.", "You open the door and head into the next room"}, keypad);
                access = false;
                timesInteracted = 3;
                
            }
            else if (input.text != "581301134181981301981413")
            {
                gDM.InteractionAfterInput(new string[] {"Beep beep. The keypad turns red.", "Lucas: I don't think that was the right " +
                    "answer."}, keypad);
                access = false;
            }
        }
        else if (timesInteracted == 3)
        {
            blackPanel.SetActive(true);
            Room2RawTime = 1800 - Mathf.RoundToInt(Timer.time);
            gM.roomNum = 3;
        }
    }
}
