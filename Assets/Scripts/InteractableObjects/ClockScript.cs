using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{

    public bool clockActive = false;
    private GameDialogHolder gDH;
    private GameDialogManager gDM;
    private PlayerInteract playerInteract;
    public GameObject inputField;
    public InputField input;
    public int timesInteracted = 1;
    public bool access;
    public GameObject clock;


    // Start is called before the first frame update
    void Start()
    {
        gDH = FindObjectOfType<GameDialogHolder>();
        gDM = FindObjectOfType<GameDialogManager>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

    public void DoInteraction()
    {
        if (clockActive)
        {
            if (timesInteracted == 1)
            {
                playerInteract.currentlyInteracting = true;
                gDH.dialogLines = new string[] {"Lucas: Huh. Interesting.", "Lucas finds a paper behind the clock", 
                    "Lucas: A code?", "You have stumbled upon a piece of paper behind the clock. On the paper, the code reads out:" +
                    " *   ***   -*-*   *-   *--*   *", "Lucas: Well then. Let’s give this a try." };
                access = true;
                gDM.ShowDialogue(clock);
            }
            else if (timesInteracted == 2)
            {
                playerInteract.currentlyInteracting = true;
                gDH.dialogLines = new string[] {"Lucas: Lets see if I can decode this." };
                inputField.SetActive(true);
                access = true;
                gDM.ShowDialogue(clock);
            }
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
            if (input.text.ToUpper() == "ESCAPE" && access)
            {
                playerInteract.currentlyInteracting = true;
                inputField.SetActive(false);
                input.text = "";
                gDH.dialogLines = new string[] { "Lucas: I got ESCAPE.", "Lucas: I guess I need to use this word as a clue."};
                gDM.ShowDialogue(clock);
                access = false;
                timesInteracted = 3;
            }
            else if (input.text.ToUpper() != "ESCAPE" && access)
            {
                playerInteract.currentlyInteracting = true;
                gDH.dialogLines = new string[] { "Lucas: I'm not sure if this is the right answer." };
                gDM.ShowDialogue(clock);
                access = false;
            }
        }
    }

}
