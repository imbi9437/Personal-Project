using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int slotCount;
    public int SlotCount { get { return slotCount; } set { slotCount = value; } }

    private Item[] items;
    public Item[] Items { get { return items; } set { items = value; } }

    public void GetItem(Item item)
    {
        if(FindItem(item)==0)
        {
            for (int i = 0; i < items.Length; i++)
            {

            }
        }
    }
    public int FindItem(Item item)
    {
        int count = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].ItemData == item.ItemData)
            {
                count++;
            }
        }
        return count;
    }
}
