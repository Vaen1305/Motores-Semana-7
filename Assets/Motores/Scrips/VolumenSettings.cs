using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumenSettings : MonoBehaviour
{
    public static VolumenSettings instance;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMasterVolumen(float volume)
    {
        float volumen = MasterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volumen)*20);
    }
    public void SetMusicVolumen(float volume)
    {
        float volumen = MusicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volumen) * 20);
    }
    public void SetSFXVolumen(float volume)
    {
        float volumen = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volumen) * 20);
    }
}
