using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHolder : MonoBehaviour
{

    private DialogueManager dM;

    public string[] dialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        dM = FindObjectOfType<DialogueManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!dM.dialogActive)
            {
                dM.currentLine = 0;
                dM.ShowDialogue();
            }
        }
    }

}
