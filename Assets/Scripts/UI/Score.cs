using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextGame;
    [SerializeField] private TextMeshProUGUI scoreTextFinish;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private float scorePerSecond;
    [SerializeField] private float enemyKillPoints;

    private PlayerHealth health;
    private float score;
    private float lastScore;

    private void Awake()
    {
        score = 0;
        DontDestroyOnLoad(gameObject);
        scoreTextFinish.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
        health = FindObjectOfType<PlayerHealth>();
        highScore.text = "High Score\n" + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (scoreTextFinish.gameObject.activeSelf)
            {
                scoreTextFinish.gameObject.SetActive(false);
                highScore.gameObject.SetActive(false);
            }
            ScorePanel();
            lastScore = score;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            ScoreEndPanel();
        }

        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(scoreTextFinish.gameObject);
            Destroy(highScore.gameObject);
            Destroy(gameObject);
        }
    }

    private void ScorePanel()
    {
        if (health.AliveCheck())
        {
            scoreTextGame.text = ((int)score).ToString();
            score += scorePerSecond * Time.deltaTime;
        }
    }
    private void ScoreEndPanel()
    {
        if (lastScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore",lastScore);
        }
        scoreTextFinish.text = "Score\n" + ((int)lastScore).ToString();
        highScore.gameObject.SetActive(true);
        scoreTextFinish.gameObject.SetActive(true);
    }

    public void KillScoreUpdate()
    {
        score += enemyKillPoints;
    }
}