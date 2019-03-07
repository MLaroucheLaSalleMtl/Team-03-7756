using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text pointText;
    private int totalPoints;
    [SerializeField] private Text timerText;
    [SerializeField] private float timerCountDown = 120.0f;

    public void Update()
    {
        timerText.text = (timerCountDown - Time.deltaTime).ToString();
        pointText.text = "SCORE: 0000" + totalPoints.ToString("D2");

        if(timerCountDown <= 0.0f)
        {
            Time.timeScale = 0.0f;
            //LEVEL OVER
        }
    }

    public void AddPoints()
    {
        totalPoints += 25;
    }
}
