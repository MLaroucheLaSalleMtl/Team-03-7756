using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseScript : MonoBehaviour
{
    public GameObject panelPause;
    public static bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) { Resume(); } else { Pause(); }
        }
        
    }
    public void Pause()
    {
        panelPause.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        panelPause.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
