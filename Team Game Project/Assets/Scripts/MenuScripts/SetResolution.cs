using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    // Use this for initialization

    private string names = "SetResolution";

    private Dropdown dropdownMenu;


    private void Awake()
    {

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currResolution = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currResolution;
        resolutionDropdown.RefreshShownValue();

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

    public void SetResolutions(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
