using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2GreenDesk : DefaultInteractableScript
{
    public GameObject desk;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: There could be something on this desk.", "Lucas looks at the objects on the desk.",
            "Lucas: There's a small blood stain. I think Dr. Nefarious attempted to wipe it, with what looks like a wet wipe. " +
            "Yikes. It's disgusting how many germs there could be in that stain. I hope I don't have to touch it later."}, desk);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}

