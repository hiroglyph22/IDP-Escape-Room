using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : MonoBehaviour
{
    public GameDialogHolder gDH;
    public GameDialogManager gDM;

    public GameObject paper;

    private void Start()
    {
        gDH = FindObjectOfType<GameDialogHolder>();
        gDM = FindObjectOfType<GameDialogManager>();
    }

    public void DoInteraction()
    {
        gDH.dialogLines = new string[] { "Lucas: A paper? ", "On this piece of paper is a table with the letters " +
            "of the alphabet written from A to Z across the top and reversed along the bottom. This is called the " +
            "Atbash Table.", "Lucas: Atbash Table? Ok then. (Added Atbash Table to inventory)" };
        gDM.ShowDialogue(paper);
    }

    public void DoneWithDialogue()
    {
        paper.SetActive(false);
    }
}
