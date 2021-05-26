using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1DoorScript : MonoBehaviour
{

    public bool doorActive = false;
    public GameObject blackPanel;

    public void DoInteraction()
    {
        if (doorActive)
        {
            //blackPanel.SendMessage("BlackPanelTransitionRoom2");
            blackPanel.SetActive(true);
        }
    }

}
