using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject player;

    [HideInInspector]
    public static int enemiesDestroyed;

    [HideInInspector]
    public static bool playerDead;

    [Header("UI")]

    public GameObject gameoverPanel, levelUpText, pausemenuPanel;
    public Text endScoreText, scoreText;
    public float levelUpShowTime;

    public static GameObject _levelUpText;
    public static float _levelUpShowTime;

    public static int highscore;

    private bool gamePaused;

    private void Awake()
    {
        Time.timeScale = 1f;
        enemiesDestroyed = 0;
        playerDead = false;
        scoreText.gameObject.SetActive(true);
        gameoverPanel.SetActive(false);
        pausemenuPanel.SetActive(false);
        Instantiate(player);
        _levelUpText = levelUpText;
        _levelUpShowTime = levelUpShowTime;

        highscore = PlayerPrefs.GetInt("Highscore", 0);

        gamePaused = false;
    }

    public static bool newHighscore;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = enemiesDestroyed.ToString();

        if (playerDead) Gameover();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape");
            if (!gamePaused)
            {
                Pause();
                return;
            }
            else if (gamePaused)
            {
                Resume();
            }
        }
    }

    void Gameover()
    {
        RemoveObjects();

        if (enemiesDestroyed > highscore)
        {
            newHighscore = true;
            PlayerPrefs.SetInt("Highscore", enemiesDestroyed);
            highscore = PlayerPrefs.GetInt("Highscore", 0);
        }
        else newHighscore = false;

        scoreText.gameObject.SetActive(false);
        gameoverPanel.SetActive(true);
        endScoreText.text = "Score: " + enemiesDestroyed.ToString();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        pausemenuPanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        pausemenuPanel.SetActive(false);
    }

    void RemoveObjects()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Virus");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }

        Destroy(GameObject.Find("EnemySpawner"));
        Destroy(GameObject.Find("Player(Clone)"));

        GameObject[] levelUpText_ = GameObject.FindGameObjectsWithTag("LevelUp");
        for (int i = 0; i < levelUpText_.Length; i++)
        {
            Destroy(levelUpText_[i]);
        }
    }

    public static void LevelUp()
    {
        enemiesDestroyed += 10;
        GameObject LevelUpTextGO = Instantiate(_levelUpText, GameObject.Find("Canvas").transform);
        Destroy(LevelUpTextGO, _levelUpShowTime);
    }
}
