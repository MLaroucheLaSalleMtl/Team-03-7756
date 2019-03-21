using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text pointText;
    public int totalPoints;
    public int highestScore;
    [SerializeField] private Text timerText;
    private float timerCountDown = 90.0f;
    private EnemyBehaviour enemy;

    [SerializeField] private GameObject endGame;

    public void Start()
    {
        Time.timeScale = 1.0f;
        endGame.SetActive(false);
    }

    public void Update()
    {
        timerCountDown -= Time.deltaTime;
        timerText.text = timerCountDown.ToString("0:00");
        pointText.text = "SCORE: " + totalPoints.ToString("D4");

        if (timerCountDown <= 0.0f)
        {
            Time.timeScale = 0.0f;
            //LEVEL OVER
            endGame.SetActive(true);

            //Keep track of score
            EnterName();
            SaveScore();
        }
    }

    public void AddPoints()
    {
        totalPoints += enemy.enemyPoints;
    }

    public void SaveScore()
    {
        if (totalPoints > PlayerPrefs.GetInt("HighestScore"))
        {
            highestScore = totalPoints;
            PlayerPrefs.SetInt("HighestScore", highestScore);
            PlayerPrefs.Save();
        }
    }

    [SerializeField] private InputField playerName;

    public void EnterName()
    {
        //if (Input.GetKeyDown("Enter"))
        //{
        //    PlayerPrefs.SetString("PlayerName", playerName.text);
        //    PlayerPrefs.SetInt("PlayerScore", totalPoints);
        //    PlayerPrefs.Save();
        //}
    }
}
