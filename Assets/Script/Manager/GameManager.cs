using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private Scene curScene;

    private bool isTimeZero;
    public bool IsTimeZero
    {
        get { return isTimeZero; }
        set
        {
            isTimeZero = value;
            Time.timeScale = isTimeZero ? 0:1;
        }
    }
    public Scene CurScene { get { return curScene; } set { curScene = value; } }
    public override void Awake()
    {
        base.Awake();
    }
    public void TimeScaleChange()
    {
        IsTimeZero = !IsTimeZero;
    }
    public void Update()
    {
        curScene = SceneManager.GetActiveScene();
    }
}
