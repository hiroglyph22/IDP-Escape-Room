using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraillePaper : MonoBehaviour
{

    private PlayerInteract playerInteract;
    private GameDialogHolder gDH;
    private GameDialogManager gDM;
    public GameObject paper;

    void Start()
    {
        gDH = FindObjectOfType<GameDialogHolder>();
        gDM = FindObjectOfType<GameDialogManager>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

    public void DoInteraction()
    {
        gDH.dialogLines = new string[] { "Lucas: A paper just like last time?", "You have stumbled upon a piece of paper. " +
            "On this piece of paper is a chart of the braille alphabet and it’s translations.", "Lucas: Braille? That’s pretty " +
            "interesting. There seems to be no code on it, so I should save it for later.", "Lucas puts it in his inventory" };
        gDM.ShowDialogue(paper);
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
        paper.SetActive(false);
    }

}
