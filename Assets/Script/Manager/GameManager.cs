using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject dataObject;
    public CurSceneData curSceneData;

    public override void Awake()
    {
        base.Awake();
        dataObject = GameObject.Find("DataObject");
        curSceneData = dataObject.GetComponent<CurSceneData>();
    }



}
