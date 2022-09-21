using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;
    private InventorySlot[] slots;
    private void Update()
    {
        OnOffInventory();
    }

    private void OnOffInventory()
    {
        if(!Input.GetKeyDown(KeyCode.I))
        {
            return;
        }
        if(inventory.activeSelf)
        {
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
        }
    }
}
