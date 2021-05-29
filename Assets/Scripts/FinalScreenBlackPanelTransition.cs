using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreenBlackPanelTransition : MonoBehaviour
{

    public GameObject blackPanel;

    public void BlackPanelTransitionRoom2()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public void TurnOffBlackPanel()
    {
        blackPanel.SetActive(false);
    }

}
