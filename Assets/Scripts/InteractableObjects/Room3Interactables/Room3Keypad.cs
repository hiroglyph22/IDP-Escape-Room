using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room3Keypad : InputInteractableScript
{

    public GameObject keypad;
    public GameObject wiresPanel;
    public GameObject blackPanel;
    public GameObject wiresPanelImage;
    public Sprite finishedWiresPanel;
    public Timer timer;
    static public int Room3RawTime;

    protected override void Start()
    {
        timer = FindObjectOfType<Timer>();
        base.Start();
    }

    public void DoInteraction()
    {
        if (timesInteracted == 1)
        {
            wiresPanel.SetActive(true);
            gDM.ShowDialogue(new string[] {"Lucas: A keypad! Wait what?!", "Seems as though the keypad doesn’t work. The pad is unhinged. " +
                "Behind the keypad is a set of unconnected wires.", " To each wire, a riddle is attached, and to each outlet, an answer" +
                " is taped to it.", "The first wire’s riddle reads out: I am not a heart, a club, or a spade. I’m put on a ring when " +
                "I am made. What am I?", "The second wire’s riddle reads out: What can fly without wings?", "The third wire’s riddle " +
                "reads out: I am on maps, on walls, and on chains. What am I?", "Dr Nefarious: Hello once again! I'm here to tell you" +
                " that if you get one of these wrong and attach the wrong wires, 30 seconds will be taken away from your time! Good luck.", 
                "Lucas: Let's see if " +
                "I can find the answers " +
                "to any of these..." }, keypad);
        }
        else if (timesInteracted == 2)
        {
            wiresPanel.SetActive(true);
            gDM.ShowDialogue(new string[] {"Lucas: Let's see if I can solve the first riddle...  I am not a heart, a club, or a spade. I’m put on a ring when " +
                "I am made. What am I?" }, keypad);
            inputField.SetActive(true);
            access = true;
        }
        else if (timesInteracted == 5)
        {
            wiresPanelImage.GetComponent<Image>().sprite = finishedWiresPanel;
            wiresPanel.SetActive(true);
            gDM.InteractionAfterInput(new string[] { "Lucas: Alright lets see if I can unlock this keypad..."}, keypad);
            inputField.SetActive(true);
            access = true;
        }
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
        wiresPanel.SetActive(false);
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
            if (input.text.ToUpper() == "DIAMOND")
            {
                gDM.InteractionAfterInput(new string[] { "Lucas attaches the wire to the outlet. Nothing happens.", "Lucas: Ok I think " +
                    "I got it. Let's move onto to the next " +
                    "riddle... " +
                    "What can fly without wings?" }, keypad);
                gM.hintNum = 7;
                wiresPanel.SetActive(true);
                inputField.SetActive(true);
                timesInteracted = 3;
            }
            else if (input.text.ToUpper() != "DIAMOND")
            {
                Timer.time -= 30;
                GameManager.timeTaken[2] += 30;
                gDM.InteractionAfterInput(new string[] { "Lucas attaches the wire to the outlet. The wire and outlet sparks.", "You have lost 30 seconds."}, keypad);
                access = false;
            }
        }
        else if (timesInteracted == 3 && access)
        {
            if (input.text.ToUpper() == "TIME")
            {
                gDM.InteractionAfterInput(new string[] { "Lucas attaches the wire to the outlet. Nothing happens.", "Lucas: Ok I think " +
                    "I got it. Let's move onto to the next " +
                    "riddle... ",
                    "I am on maps, on walls, and on chains. What am I?" }, keypad);
                gM.hintNum = 8;
                wiresPanel.SetActive(true);
                inputField.SetActive(true);
                timesInteracted = 4;
            }
            else if (input.text.ToUpper() != "TIME")
            {
                Timer.time -= 30;
                GameManager.timeTaken[2] += 30;
                gDM.InteractionAfterInput(new string[] { "Lucas attaches the wire to the outlet. The wire and outlet sparks.", "You have lost 30 seconds." }, keypad);
                access = false;
                timesInteracted = 2;
            }
        }
        else if (timesInteracted == 4 && access)
        {
            if (input.text.ToUpper() == "KEY")
            {
                gDM.InteractionAfterInput(new string[] { "Lucas connects the wire to " +
                    "the designated outlet.", "The light on the keypad turns on.", "Lucas: It looks like I got it to " +
                    "work!", "Lucas: Alright I finally finished the keypad. Let's see what kind of code" +
                 " it takes.", "This is the keypad that takes in letters."}, keypad);
                gM.hintNum = 9;
                wiresPanel.SetActive(true);
                timesInteracted = 5;
                access = false;
            }
            else if (input.text.ToUpper() != "KEY")
            {
                Timer.time -= 30;
                GameManager.timeTaken[2] += 30;
                gDM.InteractionAfterInput(new string[] { "Lucas attaches the wire to the outlet. The wire and outlet sparks.", "You have lost 30 seconds." }, keypad);
                access = false;
                timesInteracted = 2;
            }
        }
        else if (timesInteracted == 5 && access)
        {
            if (input.text.ToUpper() == "PRESSURE")
            {
                gDM.InteractionAfterInput(new string[] { "The keypad lights up green.", "Lucas: Yes! The answer was PRESSURE."}, keypad);
                gM.hintNum = 10;
                timesInteracted = 6;
                access = false;
                Room3RawTime = 1800 - Mathf.RoundToInt(Timer.time);
                
                //Debug.Log();

            }
            else if (input.text.ToUpper() != "PRESSURE")
            {
                gDM.InteractionAfterInput(new string[] { "The keypad lights up red.", "Lucas: I don't think this is the right answer."}, keypad);
                access = false;
            }
        }
        else if (timesInteracted == 6)
        {
            blackPanel.SetActive(true);
        }
    }

}
