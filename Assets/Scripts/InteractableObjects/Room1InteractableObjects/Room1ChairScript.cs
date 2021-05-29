using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1ChairScript : DefaultInteractableScript
{
    public GameObject chair;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: Are there clues around these chairs?", "You have stumbled upon the chairs. Seems as " +
            "though there is nothing here to collect.", "Lucas squints at the chairs.", "Lucas: normal chairs huh..."}, chair);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
