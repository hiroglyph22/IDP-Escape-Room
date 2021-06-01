using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputInteractableScript : DefaultInteractableScript
{

    public GameObject inputField;
    public InputField input;
    public int timesInteracted = 1;
    public bool access;

    protected override void Start()
    {
        //input = FindObjectOfType<InputField>();
        base.Start();
    }
}
