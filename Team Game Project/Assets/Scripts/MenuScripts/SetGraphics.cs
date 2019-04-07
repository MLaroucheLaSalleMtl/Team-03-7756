using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]

public class SetGraphics : MonoBehaviour
{
    
    [SerializeField] private string names;


    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }



    void Start()
    {
        Dropdown dropdownMenu = GetComponent<Dropdown>();
        int val = PlayerPrefs.GetInt(names);
        dropdownMenu.value = val;

    }
}
