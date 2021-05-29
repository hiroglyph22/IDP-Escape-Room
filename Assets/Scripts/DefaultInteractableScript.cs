using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInteractableScript : MonoBehaviour
{

    public GameDialogManager gDM;
    public PlayerInteract playerInteract;
    public GameManager gM;

    protected virtual void Start()
    {
        gM = FindObjectOfType<GameManager>();
        gDM = FindObjectOfType<GameDialogManager>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

}
