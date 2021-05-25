using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameDialogManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;
    public bool dialogActive;
    public int currentLine;

    private GameDialogHolder gDH;

    public GameObject nextScene;
    public GameObject currentObject;

    public InputField inputField;


    void Start()
    {
        gDH = FindObjectOfType<GameDialogHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && EventSystem.current.currentSelectedGameObject == null)
        {
            currentLine++;
        }

        if (currentLine == gDH.dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            //if (erasing)
            //{
            //    erasingObject.SetActive(false);
            //}
            if (currentObject != null)
            {
                currentObject.SendMessage("DoneWithDialogue");
            }
            currentLine = 0;
        }
        else if (currentLine < gDH.dialogLines.Length)
        {
            dText.text = gDH.dialogLines[currentLine];
        }
    }

    //public void ShowBox(string dialogue)
    //{
    //    dialogActive = true;
    //    dBox.SetActive(true);
    //    dText.text = dialogue;
    //}

    public void ShowDialogue(GameObject theObject)
    {
        //if (erase)
        //{
        //    erasing = true;
        //    erasingobject = objecttoerase;
        //}
        currentObject = theObject; 
        dialogActive = true;
        dBox.SetActive(true);
        //currentLine = 0;
    }
}
