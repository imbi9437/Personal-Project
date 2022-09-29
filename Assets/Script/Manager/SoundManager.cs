using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgmAudioSource;
    public AudioSource effectAudioSource;

    public AudioClip[] bgmClips;

    private void Start()
    {
        bgmAudioSource = GetComponent<AudioSource>();
    }
    public void Play()
    {
        effectAudioSource.Play();
    }
    public void SetClip(AudioClip clip)
    {
        if (effectAudioSource.clip == clip)
        {
            Play();
        }
        else
        {
            effectAudioSource.clip = clip;
        }
    }
    public void SetBGM(int soundNum)
    {
        bgmAudioSource.clip = bgmClips[soundNum];
    }

}
