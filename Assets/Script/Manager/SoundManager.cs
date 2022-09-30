using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgmAudioSource;

    public AudioClip[] bgmClips;

    private void Start()
    {
        bgmAudioSource = GetComponent<AudioSource>();
    }
    public void SetBGM(int soundNum)
    {
        bgmAudioSource.clip = bgmClips[soundNum];
        bgmAudioSource.Play();
    }

}
