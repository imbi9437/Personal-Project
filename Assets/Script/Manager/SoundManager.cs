using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgmAudioSource;
    public AudioSource effectSound;


    public AudioClip[] bgmClips;
    public AudioClip[] effectClips;

    public void SetBGM(int soundNum)
    {
        bgmAudioSource.clip = bgmClips[soundNum];
        bgmAudioSource.Play();
    }
    public void SetEffect(int soundNum)
    {
        effectSound.clip = bgmClips[soundNum];
        effectSound.Play();
    }

}
