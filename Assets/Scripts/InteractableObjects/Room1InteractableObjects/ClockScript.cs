using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : InputInteractableScript
{

    public bool clockActive = false;
    public GameObject clock;
    public GameObject morseCodePanel;

    public void DoInteraction()
    {
        if (clockActive)
        {
            if (timesInteracted == 1)
            {
                morseCodePanel.SetActive(true);
                access = true;
                gDM.ShowDialogue(new string[] {"Lucas: Huh. Interesting.", "Lucas finds a paper behind the clock",
                    "Lucas: A code?", "You have stumbled upon a piece of paper behind the clock. On the paper, the code reads out:" +
                    " *   ***   -*-*   *-   *--*   *", "Lucas: Well then. Let’s give this a try." }, clock);
            }
            else if (timesInteracted == 2)
            {
                morseCodePanel.SetActive(true);
                inputField.SetActive(true);
                access = true;
                gDM.ShowDialogue(new string[] { "Lucas: Lets see if I can decode this." }, clock);
            }
        }
        else
        {
            gDM.ShowDialogue(new string[] {"Lucas: Lets see if there's anything suspicious here.", "Lucas: No from what I can see it's" +
                " just a normal clock." }, clock);
        }
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
        morseCodePanel.SetActive(false);
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
            if (input.text.ToUpper() == "ESCAPE" && access)
            {
                gM.hintNum = 3;
                gDM.InteractionAfterInput(new string[] { "Lucas: I got ESCAPE.", "Lucas: I guess I need to use this word as a clue." }, clock);
                access = false;
                timesInteracted = 3;
            }
            else if (input.text.ToUpper() != "ESCAPE" && access)
            {
                gDM.ShowDialogue(new string[] { "Lucas: I'm not sure if this is the right answer." }, clock);
                access = false;
            }
        }
    }

}
