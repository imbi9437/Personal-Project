using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControll : MonoBehaviour
{
    public Slider soundSlider;
    public Slider mouseSensitiveSlider;

    private void Start()
    {
        mouseSensitiveSlider.value = GameManager.instance.player.MouseSensitive / 200;
    }
    
    public void ExitButton()
    {
        GameManager.instance.ChangeScene("Menu");
    }

    public void SoundSet()
    {
        
    }
    public void MouseSensitiveSet()
    {
        GameManager.instance.player.MouseSensitive = 200*mouseSensitiveSlider.value;
    }
}
