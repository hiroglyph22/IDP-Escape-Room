using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject whitePanel;
    public GameObject gM;
    private GameDialogManager gDM;
    private GameDialogHolder gDH;
    private Timer timer;
    private PlayerInteract playerInteract;
    public GameObject inputField;
    public InputField input;
    private bool firstTime = true;
    private int currentHint;


    public int hintNum = 0;

    string[] hints = {"Dr. Nefarious: Your first hint is that the answer for the combination lock located on the small box rhymes with “blue” " +
            "and it’s something you’ve been looking for. I hope you use this hint wisely, detective, but I'm going to have to deduct " +
            "2 minutes from your overall time.",
        "Dr. Nefarious: Are you struggling with solving for the paper in the box? Here I’ll give you the first letter for each word. " +
            "O_ _ _  T_ _ _ W_ _ _ T_ _ _. I’m going to deduct another 2 minutes from your time.",
        "Dr. Nefarious: This hint will help give you a clue of what the answer for the morse code could be. Your hint is that the answer to the " +
            "morse code is the same as your goal for this escape room. You are trying to _____ the room. This is a very helpful hint, " +
            "so it will cost you 2 minutes of your time."};

    string[] answers = { "Dr. Nefarious: The code for the small box is “CLUE”. 1 minute will be deducted from your time", 
        "Dr. Nefarious: The answer for the " +
            "letters to numbers in the small box is " +
            "“Only Time Will Tell”. 1 min will be deducted from your time.", "Dr. Nefarious: The morse code behind the clock you were led to says " +
            "“Escape.” From there, you will input the code " +
            "into the chest and use that key to open the door. 1 min will be deducted from your time." };

    int[] hintMins = {120,120,120};

    // Start is called before the first frame update
    void Start()
    {
        whitePanel.SetActive(true);
        gDM = FindObjectOfType<GameDialogManager>();
        gDH = FindObjectOfType<GameDialogHolder>();
        timer = FindObjectOfType<Timer>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("hint") && playerInteract.currentlyInteracting == false)
        {
            playerInteract.currentlyInteracting = true;
            //Debug.Log(firstTime + " is the first time");
            if (currentHint != hintNum)
            {
                firstTime = true;
            }
            gDH.dialogLines = new string[] { hints[hintNum] };
            if (firstTime)
            {
                timer.time -= hintMins[hintNum];
                currentHint = hintNum;
            }
            else if (firstTime == false)
            {
                inputField.SetActive(true);
                input.placeholder.GetComponent<Text>().text = "Do you want to look at the answer?";
                //Debug.Log(input.text + " is the input text");
            }
            gDM.ShowDialogue(gM);
            //hintNum++;
        }
    }

    public void DoneWithDialogue()
    {
        playerInteract.currentlyInteracting = false;
        if (firstTime)
        {
            firstTime = false;
        }
        else
        {
            if (input.text.ToUpper() == "YES")
            {
                playerInteract.currentlyInteracting = true;
                input.text = "";
                input.placeholder.GetComponent<Text>().text = "Enter your guess...";
                gDH.dialogLines = new string[] { answers[hintNum] };
                timer.time -= 60;
                gDM.ShowDialogue(gM);
            }
            else
            {
                input.placeholder.GetComponent<Text>().text = "Enter your guess...";
            }
        }
    }


}
