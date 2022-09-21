using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public bool curState;
    public GameObject curUI;
    
    public void ChangeCurUI()
    {
        switch (curState)
        {
            case true:
                {
                    curState = false;
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            case false:
                {
                    curState = true;
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
        }
    }
}
