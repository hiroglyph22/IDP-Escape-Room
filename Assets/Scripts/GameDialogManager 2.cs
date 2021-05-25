using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameDialogManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;

    public int currentLine;

    public DialogHolder dH;

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
        }

        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            Debug.Log("hi");

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
