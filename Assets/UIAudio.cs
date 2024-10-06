using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    [SerializeField] private AudioClip hover, click;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SoundOnHover()
    {
        _audioSource.PlayOneShot(hover);
    }

    public void SoundOnClick()
    {
        _audioSource.PlayOneShot(click);
    }
}
