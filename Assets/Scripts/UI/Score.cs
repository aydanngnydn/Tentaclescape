using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextGame;
    [SerializeField] private TextMeshProUGUI scoreTextFinish;
    [SerializeField] private float scorePerSecond;

    private float score;
    private float lastScore;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        scoreTextFinish.gameObject.SetActive(false);
    }

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ScorePanel();
            lastScore = score;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            scoreTextFinish.gameObject.SetActive(false);

            ScoreEndPanel();
        }
    }
    
    private void ScorePanel()
    {
        scoreTextGame.text = ((int)score).ToString();
        score += scorePerSecond * Time.deltaTime;
    }
    private void ScoreEndPanel()
    {
        scoreTextFinish.text = "Score: " + ((int)lastScore).ToString();
        scoreTextFinish.gameObject.SetActive(true);
    }
}

