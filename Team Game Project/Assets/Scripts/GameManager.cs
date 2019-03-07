using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text pointText;
    private int totalPoints;
    [SerializeField] private Text timerText;
    private float timerCountDown = 20.0f;

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

        if(timerCountDown <= 0.0f)
        {
            Time.timeScale = 0.0f;
            //LEVEL OVER
            endGame.SetActive(true);
        }
    }

    public void AddPoints()
    {
        totalPoints += 25;
    }
}
