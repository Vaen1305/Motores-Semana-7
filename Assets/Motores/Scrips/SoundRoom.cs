using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRoom : MonoBehaviour
{
    [SerializeField] private SoundD _audioSettings;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_audioSource != null && _audioSettings != null && _audioSettings.SoundClip != null)
            {
                _audioSource.PlayOneShot(_audioSettings.SoundClip, _audioSettings.Volume);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_audioSource != null)
            {
                _audioSource.Stop();
            }
        }
    }
}
