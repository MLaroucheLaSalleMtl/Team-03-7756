using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Level Manager
    [SerializeField] private Text pointText;
    public int highestScore;
    [SerializeField] private Text timerText;

    public TogglePanel togglePanel;

    private float timerCountDown = 00.0f;

    private Enemy enemy;
    [SerializeField] private GameObject endGame;
    public int numberOfEnemiesToSpawn;
    public int numberOfEnemies;
    public int enemiesSpawned;

    public int levelNumber = 1;

    //ScoreBoard System
    public int totalPoints; //all the points that the player got
    private const int scoreListLength = 20; //Amount of players on the score list
    List<Score> ScoreBoardList = new List<Score>(); //score list
    [SerializeField] private GameObject leaderboardNameInput; //Panel that'll be activate when the player reach any of the top20 scores, so he/she can add their names
    [SerializeField] private InputField playerName; //The input field
    
    
    //Level Manager
    public void Start()
    {
        togglePanel.doPause();
        Time.timeScale = 1.0f;
        endGame.SetActive(false);
        
        numberOfEnemiesToSpawn = levelNumber * 5;

    }

    public void Update()
    {
        timerCountDown += Time.deltaTime;
        timerText.text = timerCountDown.ToString("0:00");
        pointText.text = "SCORE: " + totalPoints.ToString("D4");

        if (numberOfEnemiesToSpawn <= enemiesSpawned && enemiesSpawned <= numberOfEnemies && false)
        {
            togglePanel.doPause();
            endGame.SetActive(true);
            SaveScore();
        }


        
    }

    //ScoreBoard System
    public void AddPoints()
    {
        //totalPoints += enemy.EnemyPoints;
       
    }
    public void SaveScore()
    {
                //GetScore
                //int j = 1;
                //do
                //{
                //    Score playerInfo = new Score();
                //    playerInfo.PlayerName = PlayerPrefs.GetString("HighScore" + j + "playerName"); //Add the name
                //    playerInfo.PlayerScore = PlayerPrefs.GetInt("HighScore" + j + "playerScore");  //And the score to playerprefs
                //    ScoreBoardList.Add(playerInfo); //And to the list
                //    j++;
                //} while (j <= scoreListLength && PlayerPrefs.HasKey("HighScore" + j + "playerScore"));


                //If there is nothing on the score list
                if (ScoreBoardList.Count == 0)
                {
                    leaderboardNameInput.SetActive(true); //The player can add his/her name as the first high score
                    EnterName();
                    Score playerInfo = new Score();
                    playerInfo.PlayerName = PlayerPrefs.GetString("PlayerName" + "playerName");
                    playerInfo.PlayerScore = PlayerPrefs.GetInt("PlayerScore" + "playerScore"); //Take the info
                    ScoreBoardList.Add(playerInfo); //Add the info to the list
                }
                //If there is anything on the score list
                else
                {
                    for (int k = 1; k <= ScoreBoardList.Count && k <= scoreListLength; k++)
                    {
                        if (totalPoints > ScoreBoardList[k - 1].PlayerScore) //Check if the score is bigger than any score on the top20 list
                        {
                            leaderboardNameInput.SetActive(true); //If it is, the player can add his/her name
                            EnterName(); 
                            Score playerInfo = new Score();
                            playerInfo.PlayerName = PlayerPrefs.GetString("HighScore" + "playerName");
                            playerInfo.PlayerScore = PlayerPrefs.GetInt("HighScore" + "playerScore"); //Take the info
                            ScoreBoardList.Insert(k - 1, playerInfo); //Add to the list
                            break;
                        }
                        if (k == ScoreBoardList.Count && k < scoreListLength) //Check if there is 20 players on the list, in case of the player score be smaller than all other players but there is space on the list without score 
                        {
                            leaderboardNameInput.SetActive(true); //If it is, the player can add his/her name
                            EnterName();
                            Score playerInfo = new Score();
                            playerInfo.PlayerName = PlayerPrefs.GetString("HighScore" + "playerName");
                            playerInfo.PlayerScore = PlayerPrefs.GetInt("HighScore" + "playerScore"); //Take the info
                            ScoreBoardList.Add(playerInfo); //Add info to the list
                            break;
                        }
                    }
                }
                //int i = 1;
                //do
                //{
                //    PlayerPrefs.SetString("HighScore" + i + "playerName", ScoreBoardList[i - 1].PlayerName);
                //    PlayerPrefs.SetInt("HighScore" + i + "playerScore", ScoreBoardList[i - 1].PlayerScore);
                //    i++;
                //} while (scoreListLength <= i && ScoreBoardList.Count <= i);
                   
                PlayerPrefs.Save(); //Save
    }
    public void EnterName()
    {
        if (Input.GetKeyDown("Enter"))
        {
            PlayerPrefs.SetString("PlayerName", playerName.text);
            PlayerPrefs.SetInt("PlayerScore", totalPoints);
            PlayerPrefs.Save();
        }
    }
}
