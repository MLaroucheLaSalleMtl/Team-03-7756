using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AsyncOperation asyncVar;
    public GameObject panelMenu;
    public GameObject panelOptions;
    public Text savedScoreList;
    GameManager ScoreBoardList;

    public void Start()
    {
        ScoreBoardList = GetComponent<GameManager>();
        panelOptions.SetActive(false);
        panelMenu.SetActive(true);
        if (ScoreBoardList)
        {
            savedScoreList.text = ScoreBoardList.ToString();
        }

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        if (asyncVar == null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            asyncVar = SceneManager.LoadSceneAsync(currentScene.buildIndex+1);
            asyncVar.allowSceneActivation = true;
        }
    }
    public void Return()
    {
        panelOptions.SetActive(false);
        panelMenu.SetActive(true);
    }
}
