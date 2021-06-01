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
    public Text[] usernameTextBoxes;
    public Text[] timeTextBoxes;
    private List<int> sortedTimesList = new List<int>();
    private List<string> sortedUsernamesList = new List<string>();
    private List<string> usernamesList = new List<string>();
    private List<int> timesList = new List<int>();
    private string timeString;
    private List<object> exportValues = new List<object> {};

    void Start()
    {
        GetLeaderBoard();
        exportValues = new List<object> {StartScreenDialogueManager.username, Room1DoorScript.Room1RawTime,
            GameManager.hintsTaken[0], Room1DoorScript.Room1RawTime + GameManager.timeTaken[0],
            KeypadRoom2Script.Room2RawTime - Room1DoorScript.Room1RawTime,
            GameManager.hintsTaken[1], KeypadRoom2Script.Room2RawTime - Room1DoorScript.Room1RawTime + GameManager.timeTaken[1],
            Room3Keypad.Room3RawTime - KeypadRoom2Script.Room2RawTime, GameManager.hintsTaken[2],
            Room3Keypad.Room3RawTime - KeypadRoom2Script.Room2RawTime + GameManager.timeTaken[2],
            timeString};
        if (Timer.lose == false)
        {
            text.text = "You have Won! It took you " + string.Format("{0:00}:{1:00}", Mathf.FloorToInt(Room3Keypad.Room3RawTime / 60), Mathf.FloorToInt(Room3Keypad.Room3RawTime % 60)) + " minutes to clear the escape room!";
            timeString = string.Format("{0:00}{1:00}", Mathf.FloorToInt(Room3Keypad.Room3RawTime / 60), Mathf.FloorToInt(Room3Keypad.Room3RawTime % 60));
        }
        else
        {
            text.text = "Nice try. But you didn't beat the game within 30 minutes.";
            text.fontSize = 30;
            timeString = "3000";
        }
        submitButton.GetComponent<Button>();
        submitButton.onClick.AddListener(TaskOnClick);

        for (int i = 0; i < exportValues.Count; i++)
        {
            if (exportValues[i] == null)
            {
                exportValues[i] = "3000";
            }
        }
        if ((string)exportValues[0] == "3000")
        {
            exportValues[0] = "nousername";
        }
    }

    public void TaskOnClick()
    {
        exportValues.AddRange(new List<object>() { appRatingInput.text, bestPartInput.text, improveInput.text, goingToMarketInput.text});
        DataDump.CreateEntry("A", "O", exportValues, 0);
        SceneManager.LoadScene("StartMenu");
        Timer.time = 1800;
    }

    public void GetLeaderBoard()
    {
        DataDump.Initialize();
        IList<IList<object>> usernamesListInitial = DataDump.ReadEntries("A2", "A30", 0);
        IList<IList<object>> timesListInitial = DataDump.ReadEntries("K2", "K30", 0);
        foreach (IList<object> list in usernamesListInitial)
        {
            foreach (object username in list)
            {
                usernamesList.Add(username.ToString());
            }
        }
        foreach (IList<object> list in timesListInitial)
        {
            foreach (object time in list)
            {
                timesList.Add(System.Convert.ToInt32(time));
            }
        }
        sortedTimesList = timesList.ToList().OrderBy(t => t).ToList();
        sortedUsernamesList.AddRange(from time in sortedTimesList select usernamesList[timesList.IndexOf(time, 0, timesList.Count)]);
        int leaderboardLength = (sortedUsernamesList.Count <= sortedTimesList.Count ? sortedUsernamesList.Count : sortedTimesList.Count);
        for (int i=0; i < leaderboardLength; i++)
        {
            usernameTextBoxes[i].text = sortedUsernamesList[i];
            timeTextBoxes[i].text = sortedTimesList[i].ToString("00:00");
        }
    }
}
