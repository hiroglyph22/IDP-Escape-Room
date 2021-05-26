using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2IntroDialogLines : MonoBehaviour
{

    public GameDialogManager gDM;
    public GameObject gDMObject;
    public GameDialogHolder gDH;
    private PlayerInteract playerInteract;

    void Start()
    {
        gDM = FindObjectOfType<GameDialogManager>();
        gDH = FindObjectOfType<GameDialogHolder>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

    public void UpdateDialogueForRoom2()
    {
        gDH.dialogLines = new string[] { "Lucas: Wow. This room is larger than the first one. What’s all this?", "" +
            "BAM! The iron doors closes down behind you.", "Lucas: Oh no! I’m trapped again!", "You have just entered " +
            "the second room. This room contains many books and weird objects such as beakers filled with unknown liquids and " +
            "posters of circled elements in a periodic table. Start looking around the room for clues that may aid your escape." };
        gDM.ShowDialogue(gDMObject);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }
}
