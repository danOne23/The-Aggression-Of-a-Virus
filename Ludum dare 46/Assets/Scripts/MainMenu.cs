﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
