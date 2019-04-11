using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePanel : MonoBehaviour
{

    [SerializeField] private GameObject[] panels;
    [SerializeField] private Selectable[] defaultOptions;
    public GameObject gameOverPanel;
    //[SerializeField] private GameObject playerObj;
    //[SerializeField] private GameObject[] gunObj;

    public void PanelToggle(int pos)
    {
        Input.ResetInputAxes();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(pos == i);
            if (pos == i)
            {
                //defaultOptions[i].Select();
            }
        }
    }
    

    public void doPause()
    {
        if (panels[2].gameObject.activeInHierarchy == false) 
        {
            Time.timeScale = 0;
            

           // wep.GetComponent<GunFire>().enabled = false;

            Cursor.lockState = CursorLockMode.None;

            Cursor.visible = true;
            
                
                PanelToggle(2);
            
        }
        else if (panels[3].gameObject.activeInHierarchy == false)

        {
            Time.timeScale = 1;

            

            //wep.GetComponent<GunFire>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            PanelToggle(0);
        }
    }

    // Use this for initialization
    void Start()
    {
        

        PanelToggle(0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameOverPanel.gameObject.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                doPause();
            }
        }
        
    }
}
