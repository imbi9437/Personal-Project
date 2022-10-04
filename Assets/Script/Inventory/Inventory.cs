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

    public void SetItem(Item item)
    {
        int count = SameItemSltCount(item);
        if (count == 0)
        {
            if(CheckEmptySlotCount())
            {
            SetItemToEmptySlot(item);
            }
            else
            {
                return;
            }
        }
        else if (count == 1)
        {
            int slotNum = GetSlotNum(item);
            if (items[slotNum].count + item.count <= item.itemData.MaxCount)
            {
                items[slotNum].count += item.count;
            }
            else
            {
                item.count -= item.itemData.MaxCount - items[slotNum].count; //Áú¹®
                items[slotNum].count = item.itemData.MaxCount;
                SetItemToEmptySlot(item);
            }
        }
        else if (count >= 2)
        {
            for (int i = 0; i < count; i++)
            {
                int slot = GetSlotNum(item);
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
                SetItemToEmptySlot(item);
            }
        }

    }
    public void DropItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i]==item)
            {
                items[i].Drop(CurSceneData.instance.player.transform);
                items[i].itemData = null;
                items[i].count = 0;
                items[i].curAmmo = 0;

            }
        }
    }
    private int SameItemSltCount(Item item)
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
    private int GetSlotNum(Item item)
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
    private void SetItemToEmptySlot(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
                return;

            if (items[i].itemData == null)
            {
                items[i].itemData = item.itemData;
                items[i].count = item.count;
                items[i].curAmmo = item.curAmmo;
                break;
            }
        }
    }
    private bool CheckEmptySlotCount()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].itemData == null)
            {
                return true;
            }
        }
        return false;
    }
}
