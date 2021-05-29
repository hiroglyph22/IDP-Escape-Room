using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2BigTableScript : DefaultInteractableScript
{
    public GameObject table;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: Oh man look at this huge table. Looks like it should belong in a castle.", "Lucas: It looks out of place... I mean this is supposed to be a laboratory", "Lucas: Wait. Is this a clue?", "...", "Lucas: No I don't think so."}, table);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
