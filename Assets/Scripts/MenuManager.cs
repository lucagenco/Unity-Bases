using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Scenes/Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
