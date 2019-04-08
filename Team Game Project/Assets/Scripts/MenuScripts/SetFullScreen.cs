using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SetFullScreen : MonoBehaviour {

    private string names = "SetFullScreen";

    private Toggle toggleBtn;


    private void Awake()
    {
        toggleBtn = GetComponent<Toggle>();

        toggleBtn.onValueChanged.AddListener(new UnityAction<bool>(index =>
        {
            PlayerPrefs.SetInt(names, Convert.ToInt32(toggleBtn.isOn));
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        toggleBtn.isOn = Convert.ToBoolean(PlayerPrefs.GetInt(names, 0));
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
