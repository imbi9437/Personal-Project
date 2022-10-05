using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public void GoToSettingMenu()
    {
        SceneManager.LoadScene("Setting");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }
}
