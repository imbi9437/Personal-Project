using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hpText;
    [SerializeField]
    private Slider hpSlider;
    private void Start()
    {
        GameManager.instance.player.StatusUpdate += HpTextUPdate;
        GameManager.instance.player.StatusUpdate += HpSliderUpdate;
    }

    private void HpTextUPdate(float value)
    {
        hpText.text = string.Format("{0:0}", value);
    }
    private void HpSliderUpdate(float value)
    {
        hpSlider.value = value / 500;
    }
}
