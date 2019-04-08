using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]

public class SetGraphics : MonoBehaviour
{

    [SerializeField] private string names;

    public Dropdown dropdownMenu;
    int val;

    void Start()
    {
        //dropdownMenu = GetComponent<Dropdown>();
        val = PlayerPrefs.GetInt(names);
        dropdownMenu.value = val;

    }

    public void SetQuality(int quality)
    {
        PlayerPrefs.SetInt(names, val);
        PlayerPrefs.Save();
        QualitySettings.SetQualityLevel(quality);

        
    }
    
}
