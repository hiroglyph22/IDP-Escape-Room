using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3MiddleBookshelf : DefaultInteractableScript
{
    public GameObject bookshelf;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: Will there be clues in this bookshelf?", "Lucas searches through the bookshelf " +
            "for anything suspicious.", "Lucas: Nope. Just books." }, bookshelf);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
