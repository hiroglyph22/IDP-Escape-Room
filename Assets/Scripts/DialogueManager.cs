using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    
    public int currentLine;

    public DialogHolder dH;

    public GameObject inputField;

    public InputField theInputField;

    public string username;

    public GameObject nextScene;


    void Start()
    {
        dH = FindObjectOfType<DialogHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
                //dBox.SetActive(false);
                //dialogActive = false;
            currentLine++;
            if (dH.dialogueLines[currentLine] == "What is your username?")
            {
                inputField.SetActive(true);
            }
            try
            {
                if (dH.dialogueLines[currentLine - 1] == "What is your username?")
                {
                    username = theInputField.text;
                    inputField.SetActive(false);
                    print(username);
                }
            }
            catch (Exception e)
            {

            }
            if (currentLine == 9)
            {
                nextScene.SetActive(true);
            }
        }

        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
        }

        dText.text = dialogLines[currentLine];
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
