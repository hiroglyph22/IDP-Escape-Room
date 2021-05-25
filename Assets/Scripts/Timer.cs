using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time = 1800f;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            //Show lose screen
        }

        DisplayTime(time);

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
