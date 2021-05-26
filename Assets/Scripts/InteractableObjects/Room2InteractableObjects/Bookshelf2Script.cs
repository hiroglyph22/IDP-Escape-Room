using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf2Script : MonoBehaviour
{

    public bool bookshelf2Active = false;
    private Bookshelf1 bookshelf1;
    private GameDialogHolder gDH;
    private GameDialogManager gDM;
    private PlayerInteract playerInteract;
    public GameObject bookshelf2;

    void Start()
    {
        bookshelf1 = FindObjectOfType<Bookshelf1>();
        gDH = FindObjectOfType<GameDialogHolder>();
        gDM = FindObjectOfType<GameDialogManager>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }


    public void DoInteraction()
    {
        if (bookshelf2Active)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] { "Lucas looks around the second bookshelf to find a book with the title 'Final Destination'.",
            "He finds the book.", "Lucas: So, this is 'The Evil Lab.'", "In this book is a number substitution chart. ", "Lucas: " +
            "Interesting.", "He adds the book into his inventory"};
            gDM.ShowDialogue(bookshelf2);
            bookshelf1.bookshelf1Active = false;
            bookshelf2Active = false;
        }
        else if (bookshelf1.bookshelf1Active)
        {
            playerInteract.currentlyInteracting = true;
            gDH.dialogLines = new string[] { "Lucas looks around the second bookshelf to find a book with about the periodic table.",
            "He does not find anything."};
            gDM.ShowDialogue(bookshelf2);
        }
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
    }

}
