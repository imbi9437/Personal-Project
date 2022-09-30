using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingControll : MonoBehaviour
{
    public Slider masterSound;
    public Slider bgmSound;
    public Slider effectSound;
    public Slider mouseSensitiveSlider;
    public AudioMixer audioMixer;



    private void Start()
    {
        mouseSensitiveSlider.value = SettingManager.instance.mouseSensitive / 1000;
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
        SettingManager.instance.mouseSensitive = 1000*mouseSensitiveSlider.value;
    }
}
