using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{

    public InputField appRatingInput;
    public InputField bestPartInput;
    public InputField improveInput;
    public InputField goingToMarketInput;
    public Button submitButton;
    public Text text;
    private string timeString;
    private List<object> exportValues = new List<object> {};

    void Start()
    {
        DataDump.Initialize();
   
        if (Timer.lose == false)
        {
            text.text = "You have Won! It took you " + string.Format("{0:00}:{1:00}", Mathf.FloorToInt(Room3Keypad.Room3RawTime / 60), Mathf.FloorToInt(Room3Keypad.Room3RawTime % 60)) + " minutes to clear the escape room!";
            timeString = string.Format("{0:00}{1:00}", Mathf.FloorToInt(Room3Keypad.Room3RawTime / 60), Mathf.FloorToInt(Room3Keypad.Room3RawTime % 60));
        }
        else
        {
            text.text = "Nice try. But you didn't beat the game within 30 minutes.";
            text.fontSize = 30;
            timeString = "30" + Random.Range(0, 100);
        }
        exportValues = new List<object> {StartScreenDialogueManager.username, Room1DoorScript.Room1RawTime,
            GameManager.hintsTaken[0], Room1DoorScript.Room1RawTime + GameManager.timeTaken[0],
            KeypadRoom2Script.Room2RawTime - Room1DoorScript.Room1RawTime,
            GameManager.hintsTaken[1], KeypadRoom2Script.Room2RawTime - Room1DoorScript.Room1RawTime + GameManager.timeTaken[1],
            Room3Keypad.Room3RawTime - KeypadRoom2Script.Room2RawTime, GameManager.hintsTaken[2],
            Room3Keypad.Room3RawTime - KeypadRoom2Script.Room2RawTime + GameManager.timeTaken[2],
            timeString};
        submitButton.GetComponent<Button>();
        submitButton.onClick.AddListener(TaskOnClick2);

        for (int i = 0; i < exportValues.Count; i++)
        {
            if (exportValues[i] == null)
            {
                exportValues[i] = "3000";
                Debug.Log(i);
            }
        }
        if ((string)exportValues[0] == "3000")
        {
            exportValues[0] = "nousername";
        }
    }

    public void TaskOnClick2()
    {
        SceneManager.LoadScene("LeaderBoard");
        exportValues.AddRange(new List<object>() {appRatingInput.text, bestPartInput.text, improveInput.text, goingToMarketInput.text});
        DataDump.CreateEntry("A", "O", exportValues, 0);
        
    }
}
