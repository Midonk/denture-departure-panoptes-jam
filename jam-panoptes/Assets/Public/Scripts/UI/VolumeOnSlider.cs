using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class VolumeOnSlider : MonoBehaviour
{
    public AudioMixer masterMixer;
    public string volumePropertyName = "masterVol";/* 
    public string musicVolumePropertyName = "musicVol";
    public string ambianceVolumePropertyName = "ambianceVol";
    public string sfxVolumePropertyName = "sfxVol";
    public string voiceVolumePropertyName = "voiceVol"; */

    private Slider slider;

    private void Awake() {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(volumePropertyName, 1);
    }


    private void Update() {
        SetMasterSound(volumePropertyName, slider.value);
    }

    public void SetMasterSound(string propertyName, float sliderValue)
    {
        masterMixer.SetFloat (propertyName, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(propertyName, sliderValue);
    }
}
