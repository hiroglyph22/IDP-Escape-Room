using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartScreenDialogueManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;
    public bool dialogActive = true; 
    public int currentLine;
    private StartScreenDialog sSD;
    public InputField theInputField;
    public static string username;
    public GameObject nextScene;
    public GameObject inputField;

    void Start()
    {
        sSD = FindObjectOfType<StartScreenDialog>();
    }

    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (inputField.activeSelf == false)
            {
                currentLine++;
            }
            else if (theInputField.text != "")
            {
                currentLine++;
            }
            if (currentLine < sSD.dialogueLines.Length)
            {
                if (sSD.dialogueLines[currentLine] == "What is your username? (No spaces)")
                {
                    inputField.SetActive(true);
                }
                if (sSD.dialogueLines[currentLine - 1] == "What is your username? (No spaces)")
                {
                    username = theInputField.text;
                    inputField.SetActive(false);
                    print(username);
                }
            }
            if (currentLine == sSD.dialogueLines.Length)
            {
                nextScene.SetActive(true);
            }
        }

        if (currentLine >= sSD.dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
        }
        else if (currentLine < sSD.dialogueLines.Length)
        {
            dText.text = sSD.dialogueLines[currentLine];
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }
}
