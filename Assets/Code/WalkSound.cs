using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class WalkSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClipArray;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSound()
    {
        _audioSource.clip = _audioClipArray[Random.Range(0, _audioClipArray.Length)];
        //_audioSource.PlayOneShot(_audioSource.clip); 
        _audioSource.PlayScheduled(0.5f);
    }
}
