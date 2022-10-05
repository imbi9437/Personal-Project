using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgmAudioSource;
    public AudioSource effectSound;


    public AudioClip[] bgmClips;
    public AudioClip[] effectClips;

    public GameObject soundPrafab;

    public override void Awake()
    {
        base.Awake();
        SetBGM(0);
    }


    //public void Play(AudioClip clip)
    //{
    //    Instantiate(soundPrafab, transform).GetComponent<SoundPlayer>().Play(clip);
    //}
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
