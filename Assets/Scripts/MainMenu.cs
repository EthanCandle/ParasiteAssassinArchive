﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int levelChoose;
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   

    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
      public void MainMenuPick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }


}
