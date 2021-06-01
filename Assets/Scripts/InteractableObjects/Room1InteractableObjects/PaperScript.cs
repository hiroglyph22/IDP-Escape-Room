using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : DefaultInteractableScript
{

    public GameObject atbashPanel;
    public GameObject paper;
    public GameObject desk;

    public void DoInteraction()
    {
        atbashPanel.SetActive(true);
        gDM.ShowDialogue(new string[] { "Lucas: A paper? ", "On this piece of paper is a table with the letters " +
            "of the alphabet written from A to Z across the top and reversed along the bottom. This is called the " +
            "Atbash Table.", "Lucas: Atbash Table? Ok then. (Added Atbash Table to inventory)" }, paper);
        gM.currentTablePanel = atbashPanel;
        gM.panelY = -114;
    }

    public void DoneWithDialogue()
    {
        desk.GetComponent<BoxCollider2D>().enabled = true;
        playerInteract.currentlyInteracting = false;
        atbashPanel.SetActive(false);
        paper.SetActive(false);
    }
}
