using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    public Camera cam; 

    public void CameraTransitionRoom2()
    {
        transform.position = new Vector3(23.92f, 1.89f, 0);
        cam.orthographicSize = 5;
    }

    public void CameraTransitionRoom3()
    {
        transform.position = new Vector3(0.39f, -10.6f, 0);
        cam.orthographicSize = 5f;
    }
}
