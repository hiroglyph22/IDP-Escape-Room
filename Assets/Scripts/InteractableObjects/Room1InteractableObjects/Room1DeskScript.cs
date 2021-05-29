using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1DeskScript : DefaultInteractableScript
{
    public GameObject desk;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: what a normal desk.", "Lucas: ...", "Lucas: too normal in fact.", "Lucas: ...", 
            "Lucas: Ok I think it's just a normal desk." }, desk);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
