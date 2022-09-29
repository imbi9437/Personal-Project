using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Image crossHair;

    public Sprite curCrossHair;
    public Sprite[] crossHairImages;

    public GameObject curUI;

    public GameObject UIOutside;
    public GameObject[] UI;

    public TextMeshProUGUI ItemCheckEffect;

    private void Start()
    {
        curCrossHair = crossHairImages[1];
    }
    private void LateUpdate()
    {
        if (!Input.anyKey)
            return;
        UImanage();
    }

    public void UImanage()
    {
        if (curUI == null)
            curUI = UI[0];
        if (Input.GetButtonDown("Cancel"))
            ChangeUI(UI[0].name);
        if (Input.GetButtonDown("Quest"))
            ChangeUI(UI[1].name);
        if (Input.GetButtonDown("Inventory"))
            ChangeUI(UI[2].name);
    }
    public void InteractionUImanage()
    {
        InventoryManager.instance.interactionSlot.gameObject.SetActive(true);
        ChangeUI(UI[2].name);
    }
    public void ChangeUI(string UIname)
    {
        if (UIname == UI[0].name && curUI.activeSelf)
        {
            curUI.SetActive(false);
            UIOutside.SetActive(false);
            GameManager.instance.ChangeTimeScale();
            return;
        }
        if (curUI.name == UIname)
        {
            GameManager.instance.ChangeTimeScale();
            curUI.SetActive(!curUI.activeSelf);
            UIOutside.SetActive(!UIOutside.activeSelf);
        }
        else if (curUI.name != UIname && !curUI.activeSelf)
        {
            for (int i = 0; i < UI.Length; i++)
            {
                if(UIname == UI[i].name)
                {
                    curUI = UI[i];
                    curUI.SetActive(true);
                    UIOutside.SetActive(true);
                    GameManager.instance.ChangeTimeScale();
                }
            }
        }
        else
        {
            for (int i = 0; i < UI.Length; i++)
            {
                if (UIname == UI[i].name)
                {
                    curUI.SetActive(false);
                    curUI = UI[i];
                    curUI.SetActive(true);
                }
            }
        }
    }
    public void UpdateCheckUI(bool curState)
    {
        if(curState)
        {
            ItemCheckEffect.text = "Press 'G'";
        }
        else
        {
            ItemCheckEffect.text = "";
        }
    }
}
