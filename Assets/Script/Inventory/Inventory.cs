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
    public Item[] items;

    private void Awake()
    {
        items = new Item[slotCount];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Item();
        }
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
            if (items[slot].count + item.count <= item.itemData.MaxCount)
            {
                items[slot].count += item.count;
            }
            else
            {
                item.count -= item.itemData.MaxCount - items[slot].count; //Áú¹®
                items[slot].count = item.itemData.MaxCount;
                GetItemEmpty(item);
            }
        }
        else if (count >= 2)
        {
            for (int i = 0; i < count; i++)
            {
                int slot = GetNumSlot(item);
                if (items[slot].count + item.count <= item.itemData.MaxCount)
                {
                    items[slot].count += item.count;
                    return;
                }
                else
                {
                    item.count -= item.itemData.MaxCount - items[slot].count;
                    items[slot].count = item.itemData.MaxCount;
                }
            }
            if(item.count > 0)
            {
                GetItemEmpty(item);
            }
        }

    }
    public void DropItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i]==item)
            {
                items[i].Drop(GameManager.instance.player.transform);
                items[i].itemData = null;
                items[i].count = 0;

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
            if (items[i].itemData == item.itemData && items[i].count < item.itemData.MaxCount)
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
            if (items[i].itemData == item.itemData && items[i].count < item.itemData.MaxCount)
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
            if (items[i].itemData == null)
            {
                items[i].itemData = item.itemData;
                items[i].count = item.count;
                break;
            }
        }
    }
}
