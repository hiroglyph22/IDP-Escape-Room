using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : InputInteractableScript
{

    private Room1DoorScript doorScript;
    public GameObject chest;
    public GameObject lockPanel;

    protected override void Start()
    {
        doorScript = FindObjectOfType<Room1DoorScript>();
        base.Start();
    }

    public void DoInteraction()
    {
        if (timesInteracted == 1)
        {
            lockPanel.SetActive(true);
            gDM.ShowDialogue(new string[] { "Lucas: I hear something rattling inside. It sounds like a key! ",
            "It seems that the chest has been closed off by a combination lock with the alphabet." +
            "Continue to look around the room and gather clues to unlock this chest." }, chest);
        }
        else if (timesInteracted == 2)
        {
            lockPanel.SetActive(true);
            inputField.SetActive(true);
            access = true;
            gDM.ShowDialogue(new string[] { "Lucas: Lets see if I can open this chest." }, chest);
        }
    }

    public void DoneWithDialogue()
    {
        lockPanel.SetActive(false);
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
                gDM.InteractionAfterInput(new string[] { "The chest opens.", "Lucas: Yes it looks like ESCAPE was the answer!",
                    "Inside the chest is a key.", "Lucas: Finally! A key!", "Lucas takes the key"}, chest);
                access = false;
                timesInteracted = 3;
                doorScript.doorActive = true;
            }
            else if (input.text.ToUpper() != "ESCAPE" && access)
            {
                gDM.InteractionAfterInput(new string[] { "Lucas: I tried but nothing happened. I don't think this is the right answer."
                }, chest);
                access = false;
            }
        }
    }

}
