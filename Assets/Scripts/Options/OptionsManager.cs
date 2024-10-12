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
    [SerializeField]
    private Slider sfxVolumeSlider;
    [SerializeField]
    private Slider voicesVolumeSlider;
    [SerializeField]
    private Slider musicVolumeSlider;

    [Header("Graphics")]
    [SerializeField]
    private Slider framerateSlider;

    [SerializeField]
    private Toggle vsyncToggle;

    [Header("TMP")]
    [SerializeField]
    private TextMeshProUGUI overallVolumeTMP;

    [SerializeField]
    private TextMeshProUGUI sfxVolumeTMP;

    [SerializeField]
    private TextMeshProUGUI voicesVolumeTMP;

    [SerializeField]
    private TextMeshProUGUI musicVolumeTMP;
    [SerializeField]
    private TextMeshProUGUI framerateTMP;

    private void Start() {

        gameOptions = new GameOptions();
        // SetSavedOptions();
    }



    public void ToggleVSync()
    {
        gameOptions.vsync = !gameOptions.vsync;
        QualitySettings.vSyncCount = gameOptions.vsync ? 1 : 0;
        PlayerPrefs.SetInt("VSync", gameOptions.vsync ? 1 : 0);

        PlayerPrefs.Save();

    }

    public void SetFrameRate()
    {
        int value = (int)framerateSlider.value;
        gameOptions.refreshRate = value;
        Application.targetFrameRate = value;
        framerateTMP.text = value.ToString();
        PlayerPrefs.SetInt("FrameRate", value);

        PlayerPrefs.Save();


    }


    public void SetOverallVolume()
    {
        float value = overallVolumeSlider.value;

        AudioManager.Instance.overallVolume = value;
        overallVolumeTMP.text = value.ToString("P0");
        PlayerPrefs.SetFloat("Overall Volume", AudioManager.Instance.overallVolume);

        PlayerPrefs.Save();

    }

    public void SetSFXVolume()
    {
        float value = sfxVolumeSlider.value;
        AudioManager.Instance.SFXVolume(value);
        sfxVolumeTMP.text     = value.ToString("P0");
        PlayerPrefs.SetFloat("SFX Volume", value);

        PlayerPrefs.Save();


    }

    public void SetMusicVolume()
    {
        float value = musicVolumeSlider.value;
        AudioManager.Instance.MusicVolume(value);
        musicVolumeTMP.text   = value.ToString("P0");
        PlayerPrefs.SetFloat("Music Volume", value);

        PlayerPrefs.Save();


    }


    public void SetVoiceVolume()
    {
        float value = voicesVolumeSlider.value;
        AudioManager.Instance.VoiceVolume(value);
        voicesVolumeTMP.text  = value.ToString("P0");
        PlayerPrefs.SetFloat("Voices Volume", value);

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

