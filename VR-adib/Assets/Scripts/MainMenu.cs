using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public bool isClover;
    public bool isMemory;
    public bool isSettings;
    public bool isQuit;
    public bool isHub;


    void OnMouseUp()
    {
        if (isClover)
        {
            SceneManager.LoadScene(1);
        }
        if (isMemory)
        {
            SceneManager.LoadScene(2);
        }
        if (isSettings)
        {
            SceneManager.LoadScene(3);
        }
        if (isQuit)
        {
            Application.Quit();
        }
        if (isHub)
        {
            SceneManager.LoadScene(4);
        }
    }
}
