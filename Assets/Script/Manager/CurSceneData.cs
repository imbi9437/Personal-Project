using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurSceneData : MonoBehaviour
{
    public GameObject Airplane;
    public static CurSceneData instance;
    public Player player;
    public UIChange uiChange;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(AirplaneAcitve());
    }
    IEnumerator AirplaneAcitve()
    {
        yield return new WaitForSeconds(2f);
        Airplane.SetActive(true);
        while(true)
        {
            yield return new WaitUntil(() => Airplane.activeSelf == false);
            yield return new WaitForSeconds(Random.Range(0f, 30f));
            Airplane.SetActive(false);
        }
    }
}
