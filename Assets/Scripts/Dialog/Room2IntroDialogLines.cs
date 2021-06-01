using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2IntroDialogLines : DefaultInteractableScript
{

    public GameObject gDMObject;

    public void UpdateDialogueForRoom2()
    {
        gDM.ShowDialogue(new string[] { "Lucas: Wow. This room is larger than the first one. What’s all this?", "" +
            "BAM! The iron doors closes down behind you.", "Lucas: Oh no! I’m trapped again!", "You have just entered " +
            "the second room. This room contains many books and weird objects such as beakers filled with unknown liquids and " +
            "posters of circled elements in a periodic table. Start looking around the room for clues that may aid your escape." },
            gDMObject);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
