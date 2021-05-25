using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDialogHolder : MonoBehaviour
{

    public GameDialogManager gDM;

    public string[] dialogLines;

    // Start is called before the first frame update
    void Start()
    {
        gDM = FindObjectOfType<GameDialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (gDM.currentLine < dialogLines.Length)
        //{ 
        //    if (Input.GetKeyUp(KeyCode.Space))
        //    {
        //        if (!gDM.dialogActive)
        //        {
        //            //gDM.currentLine = 0;
        //            Debug.Log("Going thro gamedialogholder");
        //            gDM.ShowDialogue(null);
        //        }
        //    }
        //}
    }
}
