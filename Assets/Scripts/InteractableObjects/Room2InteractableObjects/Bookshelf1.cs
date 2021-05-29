using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf1 : InputInteractableScript
{

    public bool bookshelf1Active = false;
    public GameObject bookshelf1;
    private Bookshelf2Script bookshelf2Script;

    public GameObject book1Panel;

    protected override void Start()
    {
        bookshelf2Script = FindObjectOfType<Bookshelf2Script>();
        base.Start();
    }

    public void DoInteraction()
    {
        if (bookshelf1Active)
        {
            if (timesInteracted == 1)
            {
                book1Panel.SetActive(true);
                gDM.ShowDialogue(new string[] { "Lucas looks around the first bookshelf to find a book with about the periodic table.",
            "He finds a book about chemistry.", "Lucas: Oh, I see now. A periodic table is a given when it comes to chemistry.",
                "You have just picked up a chemistry book. In this book, is a title for another book and words that have been bolded " +
                "unlike the others. The book title mentioned in the book is “The Evil Lab.” The bolded words were Final Destination.",
                "Lucas: What’s the purpose for the title and random words?", "Lucas: What’s the purpose for the title and random words?",
                "Lucas puts the book in his inventory."}, bookshelf1);
                bookshelf2Script.bookshelf2Active = true;
            }
            else if (timesInteracted == 2)
            {
                gDM.ShowDialogue(new string[] { "Lucas looks around the first bookshelf to find a book with the title " +
                    "'Final Destination'", "He does not find anything."}, bookshelf1);
            }
        }
    }

    public void DoneWithDialogue()
    {
        book1Panel.SetActive(false);
        playerInteract.currentlyInteracting = false;
        if (timesInteracted == 1)
        {
            timesInteracted = 2;
        }
    }
}
