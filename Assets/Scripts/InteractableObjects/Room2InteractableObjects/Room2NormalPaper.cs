using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2NormalPaper : DefaultInteractableScript
{
    public GameObject paper;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: Oh look there's a piece of paper.", "You have stumbled upon this table that has a " +
            "piece of paper on top. Seems as though there is nothing written on the paper though.", "Lucas: Well shoot! I should " +
            "investigate somewhere else. " }, paper);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
