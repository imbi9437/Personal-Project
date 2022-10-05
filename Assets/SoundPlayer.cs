using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        audioSource.clip = clip;
        StartCoroutine(PlayCo());
    }

    IEnumerator PlayCo()
    {
        while(true)
        {
            yield return null;
            //clip이 끝날때 Destroy(gameObject);
        }
    }

}
