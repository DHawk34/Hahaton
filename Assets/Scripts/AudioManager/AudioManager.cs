using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds, voiceSounds;
    public AudioSource musicSource, sfxSource, voiceSource;

    public float overallVolume;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music not founds");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
            musicSource.loop = true;
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX not founds");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlayVoice(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX not founds");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void setOverallVolume(float volume)
    {
        // overallVolume = volume;
        //Костыль
        MusicVolume(volume);
        SFXVolume(volume);
        VoiceVolume(volume);
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void VoiceVolume(float volume)
    {
        voiceSource.volume = volume;
    }

    // public float GetMusicVolume()
    // {
    //     return musicSource.volume;
    // }

    // public float GetSFXVolume()
    // {
    //     return sfxSource.volume;
    // }

    // public float GetVoicesVolume()
    // {
    //     return voiceSource.volume;
    // }

    //     public void ToggleMusic()
    // {
    //     musicSource.mute = !musicSource.mute;
    // }
    
    // public void ToggleSFX()
    // {
    //     sfxSource.mute = !sfxSource.mute;
    // }

    // public void ToggleVoice()
    // {
    //     voiceSource.mute = !sfxSource.mute;
    // }

}
