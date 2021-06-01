using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreenDialogueManager : DefaultInteractableScript
{

    public GameObject dialogueManager;
    public GameObject blackPanel;

    protected override void Start()
    {
        base.Start();
        if (Timer.lose == false)
        {
            gDM.ShowDialogue(new string[] { "Lucas: I’m getting outta here. What?! I thought I was finally out!",
                "Seems as though you can’t leave quite yet. In order to escape this facility, you must get through this prison cell " +
                "door. For this, you must need a card for the card swiper, which will be your key out of here.", 
                "Dr. Nefarious: Did you really think that those were the only things up my sleeve?",
                "There on the other side of the bars was Dr. Nefarious.",
                "Lucas: Seriously? If there was nothing blocking me, I would’ve strangled you by now!",
                "Dr. Nefarious: Haha. Hahaha. HAHAHAHAHA",
                "Lucas: Oh no! What should I do…?",
                "Lucas: That's right! I had that card that I hadn't used yet!",
                "Lucas gets up and gets out his card. Dr. Nefarious turns blue as he walks towards the door, slides the card, and then opens the door. Dr. Nefarious just stands there in shock.",
                "Lucas: Dr. Nefarious, you are under arrest."}, dialogueManager);
        }
        else
        {
            gDM.ShowDialogue(new string[] { "Lucas: ...", 
                "Dr. Nefarious: Well well well.",
                "Dr. Nefarious: It looks like you have run out of time.",
                "Dr. Nefarious: mwa ha ha. MWA HAHAHAHA",
                "Dr. Nefarious: You are going to be stuck here until your death!" }, dialogueManager);

        }  
    }

    public void DoneWithDialogue()
    {
        blackPanel.SetActive(true);
    }
}
