using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingControll : MonoBehaviour
{
    public Slider masterSound;
    public Slider bgmSound;
    public Slider effectSound;
    public Slider mouseSensitiveSlider;
    public AudioMixer audioMixer;



    private void Start()
    {
        mouseSensitiveSlider.value = GameManager.instance.player.MouseSensitive / 200;
    }

    public void SoundSet()
    {
        audioMixer.SetFloat("master", masterSound.value);
    }
    public void BGMSet()
    {
        audioMixer.SetFloat("bgm", bgmSound.value);
    }
    public void EffectSet()
    {
        audioMixer.SetFloat("effect", effectSound.value);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void MouseSensitiveSet()
    {
        GameManager.instance.player.MouseSensitive = 200*mouseSensitiveSlider.value;
    }
}
