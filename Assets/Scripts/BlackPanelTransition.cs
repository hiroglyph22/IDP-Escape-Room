using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPanelTransition : MonoBehaviour
{

    public GameObject blackPanel;
    public GameObject cam;
    public GameObject player;
    public GameObject dialogueManager;

    private int transitionCount = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void BlackPanelTransitionRoom2()
    {
        if (transitionCount == 1)
        {
            cam.SendMessage("CameraTransitionRoom2");
            player.SendMessage("PlayerTransitionRoom2");
            dialogueManager.SendMessage("UpdateDialogueForRoom2");
            transitionCount++;
        }
        else
        {
            cam.SendMessage("CameraTransitionRoom3");
            player.SendMessage("PlayerTransitionRoom3");
            dialogueManager.SendMessage("UpdateDialogueForRoom3");
        }
        
    }

    public void TurnOffBlackPanel()
    {
        blackPanel.SetActive(false);
    }
}
