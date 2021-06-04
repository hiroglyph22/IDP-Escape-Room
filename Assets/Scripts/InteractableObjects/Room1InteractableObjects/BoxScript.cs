using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxScript : InputInteractableScript
{
    private ClockScript clockScript;
    public GameObject clock;
    public Sprite clock_paper;
    public GameObject box;
    public GameObject boxPanel;
    public GameObject letterNumberPanel;
    public GameObject morseCodeChartPanel;
    public GameObject boxKey;

    protected override void Start()
    {
        clockScript = FindObjectOfType<ClockScript>();
        base.Start();
    }

    public void DoInteraction()
    {
        if (timesInteracted == 1)
        {
            boxPanel.SetActive(true);
            gDM.ShowDialogue(new string[] {"Lucas: Another item? Can I open it?", "You have stumbled upon the " +
                "box on the desk. Seems as if you can’t open it just yet. Attached to the box is a combination lock " +
                "filled with the letters of the alphabet. A cipher is engraved on top of the box.", "Lucas: XOFV? That’s not even " +
                "a word!" }, box);
        }
        else if (timesInteracted == 2)
        {
            boxPanel.SetActive(true);
            gDM.ShowDialogue(new string[] { "Lucas: Lets see if I can decode the cipher..." }, box);
            inputField.SetActive(true);
            access = true;
        }
        else if (timesInteracted == 3)
        {
            letterNumberPanel.SetActive(true);
            gDM.ShowDialogue(new string[] { "Lucas: Lets see if I can decode this second cipher..." }, box);
            inputField.SetActive(true);
            access = true;
        }
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
        boxPanel.SetActive(false);
        letterNumberPanel.SetActive(false);
        morseCodeChartPanel.SetActive(false);
        if (inputField.activeSelf)
        {
            inputField.SetActive(false);
        }
        if (timesInteracted == 1)
        {
            timesInteracted = 2;
        }
        else if (timesInteracted == 2 && access)
        {
            if (input.text.ToUpper() == "CLUE")
            {
                boxKey.SetActive(false);
                gM.hintNum = 1;
                letterNumberPanel.SetActive(true);

                gDM.InteractionAfterInput(new string[] { "Lucas: Sweet it opened up. Looks like the answer was CLUE.", "Lucas: Wait... there's " +
                "more paper?", "Inside this box is a piece of paper with a letters to numbers table and a cipher. It " +
                "also contains another piece of paper, which contains a table with what seems to be instructions to " +
                "decode morse code.", "On the first paper, the cipher reads out: O,14,12,25 T,9,13,E 23,I,12,12 20,5,12,12.",
                "Lucas: A combination of both letters and numbers? I think I should figure it out real quick."}, box);

                access = false;
                timesInteracted = 3;
            }
            else if (input.text.ToUpper() != "CLUE")
            {
                gDM.InteractionAfterInput(new string[] { "Lucas: I tried to open it but nothing happened." }, box);
                access = false;
            }
        }
        else if (timesInteracted == 3)
        {
            if (input.text.ToUpper() == "ONLY TIME WILL TELL" && access)
            {
                gM.hintNum = 2;
                morseCodeChartPanel.SetActive(true);

                gDM.InteractionAfterInput(new string[] {"Lucas: I got ONLY TIME WILL TELL.",
                    "Lucas: I’ll just save the other paper for later. (Adds paper to inventory)", "Lucas: Hmm. " +
                    "Something that relates to time..." }, box);

                gM.currentTablePanel = morseCodeChartPanel;
                gM.panelY = 6f;
                access = false;
                timesInteracted = 4;
                clock.GetComponent<SpriteRenderer>().sprite = clock_paper;
                clockScript.clockActive = true;
                clockScript.timesInteracted = 1;
            }
            else if (input.text.ToUpper() != "ONLY TIME WILL TELL" && access)
            {
                gDM.InteractionAfterInput(new string[] { "Lucas: I'm not sure if this is the right answer." }, box);
                access = false;
            }
        }
    }
}
