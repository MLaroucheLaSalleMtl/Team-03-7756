using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]

public class SetGraphics : MonoBehaviour
{

    private string names = "SetGraphics";

    private Dropdown dropdownMenu;


    private void Awake()
    {
        dropdownMenu = GetComponent<Dropdown>();

        dropdownMenu.onValueChanged.AddListener(new UnityAction<int>(index =>
       {
           PlayerPrefs.SetInt(names, dropdownMenu.value);
           PlayerPrefs.Save();
       }));
    }
    void Start()
    {
        dropdownMenu.value = PlayerPrefs.GetInt(names, 0);
    }


    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
    
}
