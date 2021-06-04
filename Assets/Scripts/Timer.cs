using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public static float time = 1800f;
    public Text text;
    static public bool lose = false;
    public GameObject timer;
    public GameObject blackPanel;
    public GameDialogManager gDM;
    static public bool timerOn = false;

    public void Start()
    {
        gDM = FindObjectOfType<GameDialogManager>();
        Debug.Log(gDM);
    }

    void Update()
    {
        if (timerOn)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                if (lose == false)
                {
                    lose = true;

                    //Show lose screen
                    //Debug.Log(gDM);
                    gDM.ShowDialogue(new string[] { "BEEEEP. BEEEP. BEEEEP." }, timer);
                    Debug.Log("Hi");
                }

            }

            DisplayTime(time);
        }
    }

    public void DoneWithDialogue()
    {
        blackPanel.SetActive(true);
        BlackPanelTransition.transitionCount = 3;
        Debug.Log("Dialogue done");
    }

    void DisplayTime(float displayingTime)
    {
        if(displayingTime < 0)
        {
            displayingTime = 0;
        }

        float min = Mathf.FloorToInt(displayingTime / 60);
        float sec = Mathf.FloorToInt(displayingTime % 60);

        text.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
