using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour
{
    private GameDialogHolder gDH;
    private GameDialogManager gDM;
    private GameManager gM;
    private PlayerInteract playerInteract;
    private ClockScript clockScript;
    public GameObject inputField;
    public InputField input;
    public GameObject clock;
    public Sprite clock_paper;

    public GameObject box;
    public int timesInteracted = 1;
    public bool access;

    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
        gDH = FindObjectOfType<GameDialogHolder>();
        gDM = FindObjectOfType<GameDialogManager>();
        clockScript = FindObjectOfType<ClockScript>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

    public void DoInteraction()
    {
        if (timesInteracted == 1)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] {"Lucas: Another item? Can I open it?", "You have stumbled upon the " +
                "box on the desk. Seems as if you can’t open it just yet. Attached to the box is a combination lock " +
                "filled with the letters of the alphabet. A cipher is engraved on top of the box.", "Lucas: XOFV? That’s not even a word!" };
            access = true;
            //Debug.Log(gDH.dialogLines.Length + " is the length");
            //Debug.Log(gDM.currentLine + " is the current line");
            gDM.ShowDialogue(box);
        }
        else if (timesInteracted == 2)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] { "Lucas: Lets see if I can decode the cipher..." };
            gDM.ShowDialogue(box);
            inputField.SetActive(true);
            access = true;
        }
        else if (timesInteracted == 3)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] { "Lucas: Lets see if I can decode this second cipher..." };
            gDM.ShowDialogue(box);
            inputField.SetActive(true);
            access = true;
        }
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
        if (inputField.activeSelf)
        {
            inputField.SetActive(false);
        }
        if (timesInteracted == 1)
        {
            timesInteracted = 2;
        }
        else if (timesInteracted == 2)
        {
            if (input.text.ToUpper() == "CLUE" && access)
            {
                gM.hintNum = 1;
                playerInteract.currentlyInteracting = true;
                inputField.SetActive(false);
                input.text = "";
                gDH.dialogLines = new string[] { "Lucas: Sweet it openned up. Looks like the answer was CLUE.", "Lucas: Wait... there's " +
                "more paper?", "Inside this box is a piece of paper with a letters to numbers table and a cipher. It " +
                "also contains another piece of paper, which contains a table with what seems to be instructions to " +
                "decode morse code.", "On the first paper, the cipher reads out: O,14,12,25 T,9,13,E 23,I,12,12 20,5,12,12.",
                "Lucas: A combination of both letters and numbers? I think I should figure it out real quick."};
                gDM.ShowDialogue(box);
                access = false;
                timesInteracted = 3;
            }
            else if (input.text.ToUpper() != "CLUE" && access)
            {
                playerInteract.currentlyInteracting = true;
                gDH.dialogLines = new string[] { "Lucas: I tried to open it but nothing happened." };
                gDM.ShowDialogue(box);
                access = false;
                input.text = "";
            }
        }
        else if (timesInteracted == 3)
        {
            if (input.text.ToUpper() == "ONLY TIME WILL TELL" && access)
            {
                gM.hintNum = 2;
                inputField.SetActive(false);
                input.text = "";
                playerInteract.currentlyInteracting = true;
                gDH.dialogLines = new string[] {"Lucas: I got ONLY TIME WILL TELL.",
                    "Lucas: I’ll just save the other paper for later. (Adds paper to inventory)", "Lucas: Hmm. " +
                    "Something that relates to time..." };
                gDM.ShowDialogue(box);
                access = false;
                timesInteracted = 4;
                clock.GetComponent<SpriteRenderer>().sprite = clock_paper;
                clockScript.clockActive = true;
            }
            else if (input.text.ToUpper() != "ONLY TIME WILL TELL" && access)
            {
                playerInteract.currentlyInteracting = true;
                gDH.dialogLines = new string[] { "Lucas: I'm not sure if this is the right answer." };
                gDM.ShowDialogue(box);
                access = false;
                input.text = "";
            }
        }
    }
}
