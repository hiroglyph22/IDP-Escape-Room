using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3DeskWithBook : DefaultInteractableScript
{
    public GameObject desk;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: Hey look there's a candle and a book on the desk.", "The chapter title on the page " +
            "says, 'The Sun is Flat and Why It's True'", "Lucas: Umm... does Dr. Nefarious believe the sun is flat?" }, desk);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
