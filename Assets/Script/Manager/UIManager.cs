using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject curUI;

    public GameObject[] UI;

    public TextMeshProUGUI ItemCheckEffect;

    private void LateUpdate()
    {
        UImanage();
    }

    public void UImanage()
    {
        if (!Input.anyKey)
            return;
        if (curUI == null)
            curUI = UI[0];
        if (Input.GetButtonDown("Cancel"))
            ChangeUI(UI[0].name);
        if (Input.GetButtonDown("Quest"))
            ChangeUI(UI[1].name);
        if (Input.GetButtonDown("Inventory"))
            ChangeUI(UI[2].name);
        //if (Input.GetButtonDown("InterAction"))
        //{
        //    InventoryManager.instance.interactionSlot.gameObject.SetActive(true);
        //    ChangeUI(UI[2].name);
        //}
            
    }
    public void ChangeUI(string UIname)
    {
        if (UIname == UI[0].name && curUI.activeSelf)
        {
            curUI.SetActive(false);
            GameManager.instance.ChangeTimeScale();
            return;
        }
        if (curUI.name == UIname)
        {
            GameManager.instance.ChangeTimeScale();
            curUI.SetActive(!curUI.activeSelf);
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
            ItemCheckEffect.text = "G를 눌러 상호작용";
        }
        else
        {
            ItemCheckEffect.text = "";
        }
    }
}
