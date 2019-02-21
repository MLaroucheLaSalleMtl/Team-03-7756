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

    public void Start()
    {
        panelOptions.SetActive(false);
        panelMenu.SetActive(true);
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
