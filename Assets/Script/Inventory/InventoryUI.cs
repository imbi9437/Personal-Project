using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;
    private InventorySlot[] slots;

    public void SettingInventory(Inventory inventory)
    {
        for (int i = 0; i < inventory.Items.Length; i++)
        {
            slots[i].SetItem(inventory.Items[i]);
        }
    }
}
