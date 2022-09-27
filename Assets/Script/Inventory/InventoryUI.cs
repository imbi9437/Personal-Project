using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private InventorySlot[] slots;

    [SerializeField]
    private Inventory curMapping;
    public Inventory CurMapping { get{ return curMapping; } set { curMapping = value; } }

    private void Awake()
    {
        slots = GetComponentsInChildren<InventorySlot>();

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
            slots[i].SetItem(curMapping.items[i]);
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
