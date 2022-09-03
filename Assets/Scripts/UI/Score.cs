using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float scorePerSecond;

    private float score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ScorePanel();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            ScoreEndPanel();
        }
    }
    
    private void ScorePanel()
    {
        scoreText.text = ((int)score).ToString();
        score += scorePerSecond * Time.deltaTime;
        
    }
    private void ScoreEndPanel()
    {
        scoreText.text = "Score: " + ((int)score).ToString();
        score += scorePerSecond * Time.deltaTime;
    }
}

