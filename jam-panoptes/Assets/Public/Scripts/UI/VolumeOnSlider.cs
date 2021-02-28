
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeOnSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public string volumePropertyName = "masterVol";
    private Slider slider;

    private void Awake() {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(volumePropertyName, 1);
    }

    private void Update() {
        SetVolume(volumePropertyName, slider.value);
    }

    public void SetVolume(string propertyName, float sliderValue)
    {
        mixer.SetFloat (propertyName, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(propertyName, sliderValue);
    }
}
