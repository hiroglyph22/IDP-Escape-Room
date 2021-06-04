using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3TopBookshelfScript : DefaultInteractableScript
{
    public GameObject bookshelf;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: Will there be clues in this bookshelf?", "Lucas searches through the bookshelf " +
            "for anything suspicious.", "Lucas: Yeah I can't find anything." }, bookshelf);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}

