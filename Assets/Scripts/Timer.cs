using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : DefaultInteractableScript
{

    public static float time = 1800f;
    public Text text;
    static public bool lose = false;
    static public GameObject timer;
    public GameObject blackPanel;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            lose = true;
            //Show lose screen
            gDM.ShowDialogue(new string[] {"BEEEEP. BEEEP. BEEEEP."}, timer);
            
        }

        DisplayTime(time);

    }

    public void DoneWithDialogue()
    {
        blackPanel.SetActive(true);
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
