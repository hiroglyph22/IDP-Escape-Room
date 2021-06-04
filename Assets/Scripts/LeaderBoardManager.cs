using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LeaderBoardManager : MonoBehaviour
{

    public Text[] usernameTextBoxes;
    public Text[] timeTextBoxes;
    private List<int> sortedTimesList = new List<int>();
    private List<string> sortedUsernamesList = new List<string>();
    private List<string> usernamesList = new List<string>();
    private List<int> timesList = new List<int>();
    public Button resetButton;

    void Start()
    {
        GetLeaderBoard();
        resetButton.GetComponent<Button>();
        resetButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        SceneManager.LoadScene("StartMenu");
        BlackPanelTransition.transitionCount = 1;
        Timer.time = 1800;
    }

    public void GetLeaderBoard()
    {
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
        for (int i = 0; i < leaderboardLength; i++)
        {
            usernameTextBoxes[i].text = sortedUsernamesList[i];
            timeTextBoxes[i].text = sortedTimesList[i].ToString("00:00");
        }
    }
}
