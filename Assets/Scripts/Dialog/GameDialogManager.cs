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
    public bool dialogActive = true;
    public int currentLine = 0;

    public GameStartDialog gSD;
    public PlayerInteract playerInteract;

    public GameObject nextScene;
    public GameObject currentObject;

    public InputField inputField;
    public GameObject inputFieldGO;


    void Start()
    {
        gSD = FindObjectOfType<GameStartDialog>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && EventSystem.current.currentSelectedGameObject == null)
        {
            currentLine++;
        }

        if (currentLine == gSD.dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            inputFieldGO.SetActive(false);
            if (currentObject != null)
            {
                currentObject.SendMessage("DoneWithDialogue");
            }
            currentLine = 0;
        }
        else if (currentLine < gSD.dialogLines.Length)
        {
            dText.text = gSD.dialogLines[currentLine];
        }
    }

    public void ShowDialogue(string[] dialog, GameObject theObject)
    {
        gSD.dialogLines = dialog;
        currentObject = theObject; 
        dialogActive = true;
        dBox.SetActive(true);
        playerInteract.currentlyInteracting = true;
    }

    public void InteractionAfterInput(string[] dialogue, GameObject theObject)
    {
        inputFieldGO.SetActive(false);
        inputField.text = "";
        ShowDialogue(dialogue, theObject);
    }
}
