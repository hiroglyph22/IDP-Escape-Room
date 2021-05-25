using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{

    private GameDialogHolder gDH;
    private GameDialogManager gDM;
    private PlayerInteract playerInteract;
    private Room1DoorScript doorScript;
    public GameObject inputField;
    public GameObject chest;
    public InputField input;
    public int timesInteracted = 1;
    public bool access;

    private void Start()
    {
        gDH = FindObjectOfType<GameDialogHolder>();
        gDM = FindObjectOfType<GameDialogManager>();
        playerInteract = FindObjectOfType<PlayerInteract>();
        doorScript = FindObjectOfType<Room1DoorScript>();
    }

    public void DoInteraction()
    {
        if (timesInteracted == 1)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] { "Lucas: I hear something rattling inside. It sounds like a key! " +
            "It seems that the chest has been closed off by a combination lock. " +
            "Continue to look around the room and gather clues to unlock this chest." };
            gDM.ShowDialogue(chest);
            access = true;
        }
        else if (timesInteracted == 2)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] { "Lucas: Lets see if I can open this chest." };
            inputField.SetActive(true);
            access = true;
            gDM.ShowDialogue(chest);
        }
        
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
        if (inputField.activeSelf)
        {
            inputField.SetActive(false);
        }
        if (timesInteracted == 1)
        {
            timesInteracted = 2;
        }
        else if (timesInteracted == 2)
        {
            if (input.text.ToUpper() == "ESCAPE" && access)
            {
                playerInteract.currentlyInteracting = true;
                inputField.SetActive(false);
                input.text = "";
                gDH.dialogLines = new string[] { "The chest opens.", "Lucas: Yes it looks like ESCAPE was the answer!", 
                    "Inside the chest is a key.", "Lucas: Finally! A key!", "Lucas takes the key"};
                gDM.ShowDialogue(chest);
                access = false;
                timesInteracted = 3;
                doorScript.doorActive = true;
            }
            else if (input.text.ToUpper() != "ESCAPE" && access)
            {
                playerInteract.currentlyInteracting = true;
                gDH.dialogLines = new string[] { "Lucas: I tried but nothing happened. I don't think this is the right answer." };
                gDM.ShowDialogue(chest);
                access = false;
            }
        }
    }

}
