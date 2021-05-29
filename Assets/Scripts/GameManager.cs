using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : InputInteractableScript
{

    public GameObject whitePanel;
    private Timer timer;
    private bool firstTimeHint = true;
    private bool firstTimeAnswer = true;
    private int currentHint;
    private int currentAnswer;

    public GameObject currrentTablePanel = null;
    public GameObject gMObject;
    static public int[] timeTaken = new int[] {0,0,0};
    static public int[] hintsTaken = new int[] {0,0,0};
    public int roomNum = 1;

    public int hintNum = 0;

    string[] hints = {"Dr. Nefarious: Your first hint is that the answer for the combination lock located on the small box rhymes with “blue” " +
            "and it’s something you’ve been looking for. I hope you use this hint wisely, detective, but I'm going to have to deduct " +
            "2 minutes from your overall time.",

        "Dr. Nefarious: Are you struggling with solving for the paper in the box? Here I’ll give you the first letter for each word. " +
            "O_ _ _  T_ _ _ W_ _ _ T_ _ _. I’m going to deduct another 2 minutes from your time.",

        "Dr. Nefarious: This hint will help give you a clue of what the answer for the morse code could be. Your hint is that the answer to the " +
            "morse code is the same as your goal for this escape room. You are trying to _____ the room. This is a very helpful hint, " +
            "so it will cost you 2 minutes of your time.",
        "Dr. Nefarious: This puzzle was simple but I will still provide you with a hint at the " +
            "cost of 2 minutes from your overall time. The word the braille spells out is a synonym for the word cipher. Good luck and" +
            " remember the time is counting. Tik Tok Tik Tok…", 

        "Dr. Nefarious: Having trouble with the riddle I set up I see. Your " +
            "hint is that the " +
            "answer is something that helps you name the elements in chemistry. This will take away 2 minutes of your time, so it would" +
            " be best if you moved faster if you don't want to be stuck with me forever Mwa-ha-ha", 
        
        "Dr. Nefarious: I suspected you " +
            "would get stuck " +
            "on this one. Your hint is that the word ‘Final’ would be decoded into the numbers code 5813011. This hint will cost you " +
            "2 minutes of your time.", 
        
        "Dr. Nefarious: That riddle was simple but you still seem to be having some trouble.  At the cost of 2 minutes, " +
            "I will provide you with a hint! Your hint is… ‘A rock made under pressure.’", 
        
        "Dr. Nefarious: This next riddle was a tad harder than the " +
            "other. For this riddle, it will cost you 2 minutes. Your hint is ‘*Blank* flies when you're having fun", 
        
        "Dr. Nefarious: The final riddle! " +
            "Some could say the hardest! Of course, I wouldn’t. Your hint for this riddle is ‘This item is inserted into locks and turned " +
            "to open or close it’ Sadly this hint will cost you 2 minutes. Better move along!!", 
        
        "Dr. Nefarious: Having a bit of trouble detective? I can give you a hint but it will cost you. Don’t worry, it's only about two minutes! Your hint is " +
            "‘Diamonds form under this’ Have fun detective!!"};

    string[] answers = { "Dr. Nefarious: The code for the small box is “CLUE”. 1 minute will be deducted from your time", 
        "Dr. Nefarious: The answer for the " +
            "letters to numbers in the small box is " +
            "“Only Time Will Tell”. 1 min will be deducted from your time.", 
        
        "Dr. Nefarious: The morse code behind the clock you were led to says " +
            "“Escape.” From there, you will input the code " +
            "into the chest and use that key to open the door. 1 min will be deducted from your time.", 
        
        "Dr. Nefarious: The answer " +
            "for this first puzzle is “CODE”. Sadly, 1 minute will be deducted from your time.", 
        
        "Dr. Nefarious: The answer for this " +
            "second puzzle is “PERIODIC TABLE”. This will take off 1 minute from your time.", 
        
        "Dr. Nefarious: The answer for this third " +
            "puzzle is 581301134181981301981413. This will take off 1 minute from your time.",

        "Dr. Nefarious: The answer for this first riddle is 'DIAMOND'. This will take off 1 minute from your time.",

        "Dr. Nefarious: The answer for this second riddle is 'TIME'. This will take off 1 minute from your time.",

        "Dr. Nefarious: The answer for this third riddle is 'KEY'. This will take off 1 minute from your time.", 
        
        "Dr. Nefarious: The answer for the final puzzle, is 'PRESSURE'. Again, this will take 1 minute off your time." };

    protected override void Start()
    {
        whitePanel.SetActive(true);
        base.Start();
    }

    void Update()
    {
        if (Input.GetButtonDown("hint") && playerInteract.currentlyInteracting == false)
        {
            if (currentHint != hintNum)
            {
                firstTimeAnswer = true;
            }
            gDM.ShowDialogue(new string[] { hints[hintNum] }, gMObject);
            if (firstTimeHint)
            {
                Timer.time -= 120;
                timeTaken[roomNum-1] += 120;
                hintsTaken[roomNum-1] += 1;
                currentHint = hintNum;
            }
            else if (firstTimeHint == false)
            {
                inputField.SetActive(true);
                input.placeholder.GetComponent<Text>().text = "Do you want to look at the answer?";
                //Debug.Log(input.text + " is the input text");
            }
            //hintNum++;
        }
        else if (Input.GetButtonDown("pull up table") && playerInteract.currentlyInteracting == false)
        {
            if (currrentTablePanel.activeSelf)
            {
                currrentTablePanel.SetActive(false);
            }
            else
            {
                currrentTablePanel.SetActive(true);
            }
        }
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
        if (firstTimeHint)
        {
            firstTimeHint = false;
        }
        else
        {
            if (input.text.ToUpper() == "YES")
            {
                if (currentAnswer != hintNum)
                {
                    firstTimeAnswer = true;
                }
                input.text = "";
                input.placeholder.GetComponent<Text>().text = "Enter your guess...";
                if (firstTimeAnswer)
                {
                    hintsTaken[roomNum - 1] += 1;
                    Timer.time -= 60;
                    timeTaken[roomNum - 1] += 60;
                    firstTimeAnswer = false;
                }
                gDM.ShowDialogue(new string[] { answers[hintNum] }, gMObject);
            }
            else
            {
                input.placeholder.GetComponent<Text>().text = "Enter your guess...";
            }
        }
    }


}
