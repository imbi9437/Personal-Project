using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class QuickSlot : MonoBehaviour
{
    public GameObject[] quickslot;
    public void ShowCurSlot(int value)
    {
        gameObject.transform.position = quickslot[value-1].transform.position;
    }
    private void Start()
    {
        GameManager.instance.player.QuickSlotChange += ShowCurSlot;
    }
}
