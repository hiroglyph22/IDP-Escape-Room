using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1BookshelfScript : DefaultInteractableScript
{
    public GameObject bookshelf;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: Seems like Dr. Nefarious has a lot of books.", "Lucas looks through the books.", 
            "Lucas: Wait there's 'Evil Lab 2.0' but there's no 1.0. Man what a scam."}, bookshelf);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
