using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void ClickStart()
    {
        //Debug.Log("Start");
        SceneManager.LoadScene("Interview2");
    }

    public void ClickExplain()
    {
        //Debug.Log("Explain");
        SceneManager.LoadScene("Character");
    }

    public void ClickExit()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}
