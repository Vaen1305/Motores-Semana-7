using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioSettings", fileName = "AudioSettings")]

public class SoundD : ScriptableObject
{
    [SerializeField] private AudioClip _soundClip;
    [SerializeField] private float _volume;

    public AudioClip SoundClip => _soundClip;
    public float Volume => _volume;
}
