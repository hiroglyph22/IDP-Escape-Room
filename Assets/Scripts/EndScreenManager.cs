using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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

    void Start()
    {
        GetLeaderBoard();
        if (Timer.lose == false)
        {
            text.text = "You have Won! It took you " + Mathf.RoundToInt(Room3Keypad.Room3RawTime/60) + " minutes to clear the escape room!";
        }
        else
        {
            text.text = "Nice try. But you didn't beat the game within 30 minutes.";
            text.fontSize = 30;
        }
        submitButton.GetComponent<Button>();
        submitButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        DataDump.CreateEntry("A", "O", new List<object> {DialogueManager.username, Room1DoorScript.Room1RawTime,
            GameManager.hintsTaken[0], Room1DoorScript.Room1RawTime + GameManager.timeTaken[0], KeypadRoom2Script.Room2RawTime - Room1DoorScript.Room1RawTime,
            GameManager.hintsTaken[1], KeypadRoom2Script.Room2RawTime - Room1DoorScript.Room1RawTime + GameManager.timeTaken[1], Room3Keypad.Room3RawTime - (KeypadRoom2Script.Room2RawTime + Room1DoorScript.Room1RawTime), GameManager.hintsTaken[2], Room3Keypad.Room3RawTime - (KeypadRoom2Script.Room2RawTime + Room1DoorScript.Room1RawTime) + GameManager.timeTaken[2], Room3Keypad.Room3RawTime, appRatingInput.text, bestPartInput.text, improveInput.text, goingToMarketInput.text}, 0);
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
        //usernamesList.AddRange();
        sortedTimesList = timesList.ToList().OrderBy(t => t).ToList();
        sortedUsernamesList.AddRange(from time in sortedTimesList select usernamesList[timesList.IndexOf(time)]);
        int leaderboardLength = (sortedUsernamesList.Count <= sortedTimesList.Count ? sortedUsernamesList.Count : sortedTimesList.Count);
        for (int i=0; i < leaderboardLength; i++)
        {
            usernameTextBoxes[i].text = sortedUsernamesList[i];
            timeTextBoxes[i].text = sortedTimesList[i].ToString();
        }
    }
}
