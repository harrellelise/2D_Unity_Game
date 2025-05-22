using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundControl : MonoBehaviour 
{
    [SerializeField] private AudioMixer myMusicMixer;
    [SerializeField] private AudioMixer myEffectMixer;
    public void SetVolumeMusic(float sliderValue)
    {
        myMusicMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetVolumeEffect(float sliderValue)
    {
        myEffectMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
}

