using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SetSFX : MonoBehaviour
{

    [SerializeField] private AudioMixer audMixer;
    [SerializeField] private string names;

    public void SVolume(float volume)
    {
        Slider slide = GetComponent<Slider>();
        audMixer.SetFloat(names, volume);
        PlayerPrefs.SetFloat(names, volume);
        PlayerPrefs.Save();

        slide.value = volume;
    }

    // Use this for initialization
    void Start()
    {
        Slider slider = GetComponent<Slider>();
        float val = PlayerPrefs.GetFloat(names);
        slider.value = val;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
