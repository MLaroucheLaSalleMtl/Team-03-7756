using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AsyncOperation asyncVar;    

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


}
