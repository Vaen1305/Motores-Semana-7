using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] SoundD audioSetting;
    void Start()
    {
        AudioListener.volume = audioSetting.Volume;
    }
}
