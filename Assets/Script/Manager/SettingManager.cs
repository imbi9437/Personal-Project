using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : Singleton<SettingManager>
{
    [Range(0, 1000)]
    public float mouseSensitive;

    public Sprite curCrossHair;

    public Sprite[] crossHair;

}
