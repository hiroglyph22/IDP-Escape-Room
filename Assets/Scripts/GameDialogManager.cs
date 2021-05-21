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

    public GameDialogHolder gDH;

    public GameObject nextScene;


    void Start()
    {
        gDH = FindObjectOfType<GameDialogHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            //dBox.SetActive(false);
            //dialogActive = false;
            currentLine++;
            Debug.Log("Dialog Active and currentLine ++");
        }

        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            Debug.Log("Dialog Active is now false");

            currentLine = 0;
        }

        dText.text = gDH.dialogLines[currentLine];
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
