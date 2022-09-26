using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player;   
    public Airplane airplane;
    public void ChangeTimeScale()
    {
        if(Time.timeScale ==1)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void Start()
    {
        StartCoroutine(StartAirplane());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    IEnumerator StartAirplane()
    {
        while(true)
        {
            yield return new WaitForSeconds(30f);
            if(airplane.gameObject.activeSelf == false)
            {
                airplane.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(Random.Range(30f, 120f));
        }
    }
}
