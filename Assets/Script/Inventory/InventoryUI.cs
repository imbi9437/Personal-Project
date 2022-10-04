using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private InventorySlot[] slots;

    [SerializeField]
    private Inventory curMapping;
    public Inventory CurMapping { get{ return curMapping; } set { curMapping = value; SettingInventoryUI(); } }

    private void Awake()
    {
        slots = GetComponentsInChildren<InventorySlot>();
        SettingInventoryUI();
    }
    private void Update()
    {
        SettingInventoryUI();
    }
    private void LateUpdate()
    {
        SettingInventory();
    }
    public void SettingInventoryUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i>= curMapping.items.Length)
            {
                slots[i].SetItem(null);
            }
            else
            {
                slots[i].SetItem(curMapping.items[i]);
            }
        }
    }
    public void SettingInventory()
    {
        for (int i = 0; i < curMapping.items.Length; i++)
        {
            curMapping.items[i] = slots[i].SlotItem;
        }
    }
}
