using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public GameObject currentInterObj = null;
    public bool currentlyInteracting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObj != null && currentlyInteracting == false)
        {
            //Do something with the object
            currentInterObj.SendMessage("DoInteraction");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            currentInterObj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            if(collision.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
}
