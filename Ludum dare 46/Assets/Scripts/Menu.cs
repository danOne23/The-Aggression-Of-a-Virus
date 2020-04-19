using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Restart()
    {
        AudioManager.PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        AudioManager.PlayClickSound();
        Application.Quit();
    }

    public void MainMenu()
    {
        AudioManager.PlayClickSound();
        SceneManager.LoadScene("mainMenu");
    }
}
