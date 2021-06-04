using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf2Script : InputInteractableScript
{

    public bool bookshelf2Active = false;
    private Bookshelf1 bookshelf1;
    public GameObject bookshelf2;
    public GameObject book2Panel;

    protected override void Start()
    {
        bookshelf1 = FindObjectOfType<Bookshelf1>();
        base.Start();
    }


    public void DoInteraction()
    {
        if (bookshelf2Active)
        {
            gM.currentTablePanel = book2Panel;
            gM.panelY = 50f;
            book2Panel.SetActive(true);
            gDM.ShowDialogue(new string[] { "Lucas looks around the second bookshelf to find a book with the title 'Final Destination'.",
            "He finds the book.", "Lucas: So, this is 'The Evil Lab.'", "In this book is a number substitution chart. ", "Lucas: " +
            "Interesting.", "He adds the book into his inventory.", "Lucas: What’s this? There’s something in between these books!", "You have just found a card, " +
            "but what could this card be used for?", "Lucas: Nothing in this room seems to need a card though…", "Lucas adds it into " +
            "his inventory."}, bookshelf2);
            bookshelf1.bookshelf1Active = false;
            bookshelf2Active = false;
        }
        else if (bookshelf1.bookshelf1Active)
        {
            gDM.ShowDialogue(new string[] { "Lucas looks around the second bookshelf to find a book with the periodic table.",
            "He does not find anything."}, bookshelf2);
        }
    }

    public void DoneWithDialogue()
    {
        book2Panel.SetActive(false);
        playerInteract.currentlyInteracting = false;
    }

}
