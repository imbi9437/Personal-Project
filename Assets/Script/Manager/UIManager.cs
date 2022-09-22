using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject curUI;

    public GameObject[] UI;

    private void Update()
    {
        UImanage();
    }

    public void UImanage()
    {
        if (!Input.anyKey)
            return;
        if (curUI == null)
            curUI = UI[0];
        if (Input.GetButtonDown("Escape"))
            ChangeUI(UI[0].name);
        if (Input.GetButtonDown("Quest"))
            ChangeUI(UI[1].name);
        if (Input.GetButtonDown("Inventory"))
            ChangeUI(UI[2].name);
    }

    public void ChangeUI(string UIname)
    {
        if (UIname == UI[0].name && curUI.activeSelf)
        {
            curUI.SetActive(false);
            return;
        }
        if (curUI.name == UIname)
        {
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
}
