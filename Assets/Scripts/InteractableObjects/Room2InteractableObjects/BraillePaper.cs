using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraillePaper : DefaultInteractableScript
{

    public GameObject paper;
    public GameObject brailleChartPanel;

    public void DoInteraction()
    {
        brailleChartPanel.SetActive(true);
        gM.currentTablePanel = brailleChartPanel;
        gM.panelY = -12f;
        gDM.ShowDialogue(new string[] { "Lucas: A paper just like last time?", "You have stumbled upon a piece of paper. " +
            "On this piece of paper is a chart of the braille alphabet and it’s translations.", "Lucas: Braille? That’s pretty " +
            "interesting. There seems to be no code on it, so I should save it for later.", "Lucas puts it in his inventory" },paper);
    }

    public void DoneWithDialogue()
    {
        brailleChartPanel.SetActive(false);
        playerInteract.currentlyInteracting = false;
        paper.SetActive(false);
    }

}
