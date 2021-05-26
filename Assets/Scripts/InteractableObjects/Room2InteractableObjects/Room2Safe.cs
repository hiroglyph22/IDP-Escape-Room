using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room2Safe : MonoBehaviour
{

    private GameDialogHolder gDH;
    private GameDialogManager gDM;
    private PlayerInteract playerInteract;
    private Bookshelf1 bookshelf1Script;
    public GameObject safe;
    public GameObject inputField;
    public InputField input;

    private int timesInteracted = 1;
    private bool access;

    void Start()
    {
        gDH = FindObjectOfType<GameDialogHolder>();
        gDM = FindObjectOfType<GameDialogManager>();
        playerInteract = FindObjectOfType<PlayerInteract>();
        bookshelf1Script = FindObjectOfType<Bookshelf1>();
    }

    public void DoInteraction()
    {
        if (timesInteracted == 1)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] { "Lucas: A safe? What could be inside of it?", "Lucas: There seems to be something on the " +
            "safe. Something like textured dots? Like some sort of code..." };
            gDM.ShowDialogue(safe);
            access = true;
        }
        else if (timesInteracted == 2)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] {"Lucas: Lets see if I can decode the cipher..." };
            gDM.ShowDialogue(safe);
            inputField.SetActive(true);
            access = true;
        }
        else if (timesInteracted == 3)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] {
                "Lucas: The riddle says, I contain more than 100 things but " +
                "I’m not a jigsaw puzzle. I contain metals but I’m not a car. I contain hydrogen and oxygen but I’m not water. " +
                "I sound like I could be a piece of furniture but I’m not a flower bed. I’m used in chemistry but I’m not a test " +
                "tube."};
            gDM.ShowDialogue(safe);
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
        else if (timesInteracted == 2 && access)
        {
            if (input.text.ToUpper() == "CODE")
            {
                gDM.InteractionAfterInput(new string[] {"Lucas: Nice! Looks like the answer was 'CODE'", "Lucas: Now theres, a riddle...",
                "Inside the safe is a piece of paper containing a riddle.", "The riddle says, I contain more than 100 things but " +
                "I’m not a jigsaw puzzle. I contain metals but I’m not a car. I contain hydrogen and oxygen but I’m not water. " +
                "I sound like I could be a piece of furniture but I’m not a flower bed. I’m used in chemistry but I’m not a test " +
                "tube.", "Lucas: What would be something used in chemistry…? I should try to figure this one out when I can."}, safe);
                access = false;
                timesInteracted = 3;
            }
            else if (input.text.ToUpper() != "CODE")
            {
                gDM.InteractionAfterInput(new string[] { "Lucas: I tried to open it but nothing happened." }, safe);
                access = false;
            }
        }
        else if (timesInteracted == 3 && access)
        {
            if (input.text.ToUpper() == "PERIODIC TABLE")
            {
                gDM.InteractionAfterInput(new string[] { "Lucas: The periodic table, huh? How would that help me? Do I look in the " +
                    "bookshelves?"}, safe);
                access = false;
                timesInteracted = 4;
                bookshelf1Script.bookshelf1Active = true;
            }
            else if (input.text.ToUpper() != "PERIODIC TABLE")
            {
                gDM.InteractionAfterInput(new string[] { "Lucas: I'm not sure if this is the right answer." }, safe);
                access = false;
            }
        }
    }
}
