using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Text highestScore;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        PlayerPrefs.GetInt("HighestScore");

        //DISPLAY SCOREBOARD
        highestScore.text = "Best Peasant: " + PlayerPrefs.GetString("HighestName") + "     " + PlayerPrefs.GetInt("HighestScore");

    }
}
