using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkboardScript : DefaultInteractableScript
{
    public GameObject chalkBoard;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: The chalkboard is just blank...", "Lucas: And it looks a lot like a tv.", "Lucas: I " +
            "don't think there's any clues here." }, chalkBoard);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
