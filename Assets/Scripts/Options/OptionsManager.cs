using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class OptionsManager : MonoBehaviour
{
    public class OptionsChangedEvent : UnityEvent { }

    public OptionsChangedEvent DefaultSettings = new OptionsChangedEvent();

    private static GameOptions gameOptions;

    [Header("Sounds")]
    [SerializeField]
    private Slider overallVolumeSlider;

    [Header("Graphics")]
    [SerializeField]
    private Slider brightnessSilder;

    [Header("TMP")]
    [SerializeField]
    private TextMeshProUGUI overallVolumeTMP;

    [SerializeField]
    private TextMeshProUGUI brightnessTMP;

    private void Start()
    {

        gameOptions = new GameOptions();
        // SetSavedOptions();
    }

    public void SetBrightness()
    {
        float value = brightnessSilder.value;
        gameOptions.brightness = value;
        brightnessTMP.text = (value * 100).ToString("F0");
        PlayerPrefs.SetFloat("Brightness", value);

        PlayerPrefs.Save();


    }


    public void SetOverallVolume()
    {
        float value = overallVolumeSlider.value;

        AudioManager.Instance.overallVolume = value;
        overallVolumeTMP.text = (value * 100).ToString("F0");
        PlayerPrefs.SetFloat("Overall Volume", AudioManager.Instance.overallVolume);

        PlayerPrefs.Save();

    }

    public void GetSettings(ref GameOptions settings)
    {
        if (gameOptions != null)
        {
            settings = gameOptions;
            return;
        }
        settings = GetDefaultSettings();
        return;
    }

    public void ResetToDefaultSettings()
    {
        // SaveSettings(GetDefaultSettings());
        DefaultSettings.Invoke();
    }
    public GameOptions GetDefaultSettings()
    {
        return new GameOptions();
    }
}

