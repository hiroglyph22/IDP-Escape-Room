using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1DoorScript : MonoBehaviour
{

    public bool doorActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DoInteraction()
    {
        if (doorActive)
        {
            Debug.Log("Yay we are now in the second room");
        }
    }

}
