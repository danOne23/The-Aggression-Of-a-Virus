using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{

    private void OnEnable()
    {
        Text highscoreText = GetComponent<Text>();
        highscoreText.text = "Highscore: " + Manager.highscore.ToString();
    }
}
