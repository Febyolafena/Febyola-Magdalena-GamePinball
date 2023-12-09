using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiooManager : MonoBehaviour
{
    private void Start()
    {
        // BGM jalan saat game dimulai
        PlayBGM();
    }

    public AudioSource bgmAudioSource;
    public GameObject sfxAudioSource;

    public void PlayBGM() 
    { 
        bgmAudioSource.Play();
    }
    public void PlaySFX() { }

    public void PlaySFX(Vector3 spawnPosition)
    { 
        GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
    }
}
