using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3TwinDesks : DefaultInteractableScript
{
    public GameObject desks;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: There is a mirror and a potted plant. There could be a clue under them.", "Seems as " +
            "though there is nothing under both items.", "Lucas: Lucas: Well then. Time to continue searching. " }, desks);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
