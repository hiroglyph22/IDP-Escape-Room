using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject whitePanel;
    private GameDialogManager gDM;
    private GameDialogHolder gDH;
    private Timer timer;
    private PlayerInteract playerInteract;


    public int hintNum = 0;

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
            gDM.currentLine = 0;
            switch (hintNum)
            {
                case 0:
                    gDH.dialogLines = new string[] { "Hi" };
                    timer.time -= 60;
                    break;
                case 1:
                    gDH.dialogLines = new string[] { "Hi2" };
                    timer.time -= 120;
                    break;
                case 2:
                    gDH.dialogLines = new string[] { "Hi3" };
                    timer.time -= 180;
                    break;
                case 3:
                    gDH.dialogLines = new string[] { "Hi4" };
                    hintNum = -1;
                    break;
            }
            gDM.ShowDialogue(null);
            hintNum++;
        }
    }


}
