using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDialogHolder : MonoBehaviour
{

    private GameDialogManager gDM;

    public string[] dialogLines;

    // Start is called before the first frame update
    void Start()
    {
        gDM = FindObjectOfType<GameDialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!gDM.dialogActive)
            {
                gDM.dialogLines = dialogLines;
                gDM.currentLine = 0;
                gDM.ShowDialogue();
            }
        }
    }
}
