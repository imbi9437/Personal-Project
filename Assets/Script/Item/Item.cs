using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int count;
    public ItemData itemData;

    public int curAmmo;

    public void Use(Player player)
    {
        switch(itemData.ItemType)
        {
            case ItemData.ITEMTYPE.USED:
                itemData.Use(player);
                count--;
                break;
            case ItemData.ITEMTYPE.ARMOR:
                break;
            case ItemData.ITEMTYPE.GUN:
                if(curAmmo > 0)
                {
                    itemData.Use(player);
                    curAmmo--;
                }
                break;
            case ItemData.ITEMTYPE.SWORD:
                itemData.Use(player);
                break;
        }
    }
    public void Drop(Transform parent)
    {
        itemData.Drop(parent, count);
    }
    public void Reroad(Player player)
    {
        if(itemData.ItemType == ItemData.ITEMTYPE.GUN)
        {
            Gun gundata = (Gun)itemData;
            for (int i = 0; i < player.Inventory.items.Length; i++)
            {
                if (player.Inventory.items[i].itemData == gundata.NeedAmmo)
                {
                    if(player.Inventory.items[i].count+curAmmo>gundata.MaxMagazine)
                    {
                        player.Inventory.items[i].count -= gundata.MaxMagazine - curAmmo;
                    }
                    return;
                }
            }
            for (int i = 0; i < player.QuickSlot.items.Length; i++)
            {
                if (player.Inventory.items[i].itemData == gundata.NeedAmmo)
                {
                    
                    return;
                }
            }
            curAmmo = gundata.MaxMagazine;
        }
    }
}
