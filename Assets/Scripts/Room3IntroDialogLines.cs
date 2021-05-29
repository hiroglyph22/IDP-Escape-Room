using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3IntroDialogLines : Room2IntroDialogLines
{
    public void UpdateDialogueForRoom3()
    {
        gDM.ShowDialogue(new string[] { "You have just entered the final room, Dr. Nefarious’ lair.", "Lucas: Just this and I’m done." +
            " Let’s get this finished with." }, gDMObject);
    }

}
