using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int slotCount;
    public int SlotCount { get { return slotCount; } set { slotCount = value; } }

    private Item[] items;
    public Item[] Items { get { return items; } set { items = value; } }

    private void Start()
    {
        items = new Item[slotCount];
    }
    public void GetItem(Item item)
    {
        int count = CountSlots(item);
        if (count == 0)
        {
            GetItemEmpty(item);
        }
        else if (count == 1)
        {
            int slot = GetNumSlot(item);
            if (items[slot].Count + item.Count <= item.ItemData.MaxCount)
            {
                items[slot].Count += item.Count;
            }
            else
            {
                item.Count -= item.ItemData.MaxCount - items[slot].Count;
                items[slot].Count = item.ItemData.MaxCount; //Áú¹® ÇØ¾ßµÊ
                GetItemEmpty(item);
            }
        }
        else if (count >= 2)
        {
            for (int i = 0; i < count; i++)
            {
                int slot = GetNumSlot(item);
                if (items[slot].Count + item.Count <= item.ItemData.MaxCount)
                {
                    items[slot].Count += item.Count;
                    return;
                }
                else
                {
                    item.Count -= item.ItemData.MaxCount - items[slot].Count;
                    items[slot].Count = item.ItemData.MaxCount;
                }
            }
            if(item.Count > 0)
            {
                GetItemEmpty(item);
            }
        }

    }
    private int CountSlots(Item item)
    {
        int count = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i]==null)
            {
                continue;
            }
            if (items[i].ItemData == item.ItemData && items[i].Count < item.ItemData.MaxCount)
            {
                count++;
            }
        }
        return count;
    }
    private int GetNumSlot(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].ItemData == item.ItemData && items[i].Count <item.ItemData.MaxCount)
            {
                return i;
            }
        }
        return -1;
    }
    private void GetItemEmpty(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                break;
            }
        }
    }
}
