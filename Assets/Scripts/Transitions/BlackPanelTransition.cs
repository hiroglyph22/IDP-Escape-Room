using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackPanelTransition : MonoBehaviour
{

    public GameObject blackPanel;
    public GameObject cam;
    public GameObject player;
    public GameObject dialogueManager;

    static public int transitionCount = 1;

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
        else if (transitionCount == 2)
        {
            cam.SendMessage("CameraTransitionRoom3");
            player.SendMessage("PlayerTransitionRoom3");
            dialogueManager.SendMessage("UpdateDialogueForRoom3");
            transitionCount++;
        }
        else if (transitionCount == 3)
        {
            SceneManager.LoadScene("FinalScene");
            transitionCount++;
        }
        else if (transitionCount == 4)
        {
            SceneManager.LoadScene("EndScreen");
        }
        
    }

    public void TurnOffBlackPanel()
    {
        blackPanel.SetActive(false);
    }
}
