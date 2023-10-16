using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeTextUI = null;
    [SerializeField] private Slider volumeSliderSFX = null;
    [SerializeField] private Text volumeTextUISFX = null;

    private void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
        volumeTextUISFX.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        float volumeValueSFX = volumeSliderSFX.value;
        PlayerPrefs.SetFloat("volumevalue", volumeValue);
        PlayerPrefs.SetFloat("volumevalueSFX", volumeValueSFX);
        LoadValues();
    }

    public void MuteToggle(bool mute)
    {
        if (mute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("volumevalue");
        float volumeValueSFX = PlayerPrefs.GetFloat("volumevalueSFX");
        volumeSlider.value = volumeValue;
        volumeSliderSFX.value = volumeValueSFX;
        AudioListener.volume = volumeValue;
        AudioListener.volume = volumeValueSFX;
    }
}
