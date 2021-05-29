using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeScript : DefaultInteractableScript
{

    public GameObject globe;

    public void DoInteraction()
    {
        gDM.ShowDialogue(new string[] { "Lucas: Hey I can see America on the globe pointing towards me!", "Maybe it's a sign " +
            "that I'm still in the US." }, globe);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
