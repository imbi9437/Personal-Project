using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private InventorySlot[] slots;

    private void Awake()
    {
        slots = GetComponentsInChildren<InventorySlot>();
    }
    public void SettingInventory(Inventory inventory)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetItem(inventory.items[i]);
        }
    }
}
