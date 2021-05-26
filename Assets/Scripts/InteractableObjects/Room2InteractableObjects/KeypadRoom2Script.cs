using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadRoom2Script : MonoBehaviour
{

    private GameDialogHolder gDH;
    private GameDialogManager gDM;
    private PlayerInteract playerInteract;
    public GameObject keypad;
    public GameObject inputField;
    public InputField input;
    private int timesInteracted = 1;
    private bool access;

    public GameObject blackPanel;

    void Start()
    {
        gDH = FindObjectOfType<GameDialogHolder>();
        gDM = FindObjectOfType<GameDialogManager>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

    public void DoInteraction()
    {
        if (timesInteracted == 1)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] { "This is the keypad in which you must input a code to escape this room. It is a typical " +
            "keypad where you punch in the code.", "Lucas: What could the code be?" };
            gDM.ShowDialogue(keypad);
        }
        else if (timesInteracted == 2)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] { "Lucas: Lets see if I can unlock the keypad..." };
            gDM.ShowDialogue(keypad);
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
                gDM.InteractionAfterInput(new string[] {"Beep beep. The keypad turns green.", "Lucas: Yes! Looks like I got the " +
                    "answer! Man that was a long code.", "You open the door and head into the next room"}, keypad);
                access = false;
                timesInteracted = 3;
                blackPanel.SetActive(true);
            }
            else if (input.text != "581301134181981301981413")
            {
                gDM.InteractionAfterInput(new string[] {"Beep beep. The keypad turns red.", "Lucas: I don't think that was the right " +
                    "answer."}, keypad);
                access = false;
            }
        }
    }
}
