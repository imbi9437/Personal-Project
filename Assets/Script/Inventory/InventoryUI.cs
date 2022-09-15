using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventorySlot[] inventorySlots;

    private void Awake()
    {
        inventorySlots = GetComponentsInChildren<InventorySlot>();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {


            foreach(var temp in InventoryManager.instance.slotItem)
            {

                Debug.Log(temp.Value.item.Name);
            }
  
        }
    }

}
