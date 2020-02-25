using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickSound;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    public void ButtonClicked()
    {
        buttonClickSound.Play();
    }
    
    public void ToggleMasterVolume(bool enabled)
    {
        if (enabled)
        {
            _mixerGroup.audioMixer.SetFloat("MasterVolume", -80);
        }
        else
        {
            _mixerGroup.audioMixer.SetFloat("MasterVolume", 0);
        }

        PlayerPrefs.SetInt("MasterVolume", enabled ? 1 : 0);
    }

    public void ChangeEnvironmentVolume(float volume)
    {
        _mixerGroup.audioMixer.SetFloat("EnvironmentVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("EnvironmentVolume", enabled ? 1 : 0);
    }
    
    public void ChangeMusicVolume(float volume)
    {
        _mixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MusicVolume", enabled ? 1 : 0);
    }
}
