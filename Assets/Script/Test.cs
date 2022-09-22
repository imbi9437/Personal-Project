using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject curUI;

    public GameObject[] UIs;

    private void Update()
    {
        UImanage();
    }

    public void UImanage()
    {
        if (!Input.anyKey)
            return;
        if (curUI == null)
            curUI = UIs[0];
        if (Input.GetKeyDown(KeyCode.Escape))
            ChangeUI(UIs[0].name);
        if (Input.GetKeyDown(KeyCode.A))
            ChangeUI(UIs[1].name);
        if (Input.GetKeyDown(KeyCode.S))
            ChangeUI(UIs[2].name);
        if (Input.GetKeyDown(KeyCode.D))
            ChangeUI(UIs[3].name);
    }

    public void ChangeUI(string UIname)
    {
        if(UIname == UIs[0].name&&curUI.activeSelf)
        {
            curUI.SetActive(false);
            return;
        }
        if(curUI.name == UIname)
        {
            curUI.SetActive(!curUI.activeSelf);
        }
        else
        {
            for (int i = 0; i < UIs.Length; i++)
            {
                if(UIname == UIs[i].name)
                {
                    curUI.SetActive(false);
                    curUI = UIs[i];
                    curUI.SetActive(true);
                }
            }
        }
    }
}
