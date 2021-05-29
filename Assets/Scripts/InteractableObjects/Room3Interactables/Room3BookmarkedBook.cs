using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3BookmarkedBook : InputInteractableScript
{

    public GameObject bookmarkedBook;
    public GameObject bookPanel;

    public void DoInteraction()
    {
        if (timesInteracted == 1)
        {
            bookPanel.SetActive(true);
            gDM.ShowDialogue(new string[] {"Lucas: What does this book have to do with anything?", "You open up the book on the desk." +
            "", "Lucas: Is this a grid?", "In this book contains a grid code, also known as a vigenère. To use this code you must read" +
            " the first digit of the number according to its row (left to right), then read the second digit of the number according " +
            "to its column (up and down).", "The numbers under the grid code reads: 53 24 51 34 34 54 24 51."}, bookmarkedBook);
        }
        else if (timesInteracted == 2)
        {
            bookPanel.SetActive(true);
            gDM.ShowDialogue(new string[] {"The numbers under the grid code reads: 53 24 51 34 34 54 24 51.", "Let's see if I can " +
                "figure out what it's saying..." }, bookmarkedBook);
            inputField.SetActive(true);
            access = true;
        }
    }

    public void DoneWithDialogue()
    {
        bookPanel.SetActive(false);
        playerInteract.currentlyInteracting = false;
        if (inputField.activeSelf)
        {
            inputField.SetActive(false);
        }
        if (timesInteracted == 1)
        {
            timesInteracted = 2;
        }
        if (timesInteracted == 2)
        {
            if (input.text.ToUpper() == "PRESSURE" && access)
            {
                gM.hintNum = 3;
                gDM.InteractionAfterInput(new string[] { "Lucas: Ok. I got PRESSURE. That seems right.", "Lucas: I guess I need to " +
                    "use this word as a clue for something else." },
                    bookmarkedBook);
                access = false;
                timesInteracted = 3;
            }
            else if (input.text.ToUpper() != "PRESSURE" && access)
            {
                gDM.ShowDialogue(new string[] { "Lucas: I'm not sure if this is the right answer. It doesn't seem right." }, bookmarkedBook);
                access = false;
            }
        }
    }

}
