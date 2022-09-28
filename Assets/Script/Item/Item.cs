using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public enum ITEMTYPE { EQUIPMENT, USED, WEAPON }

    public ITEMTYPE itemtype;
    public bool canUseOnClick;
    public bool canUseInventory;
    public int count;
    public ItemData itemData;

    private int curAmmo;

    public void Use(Player player)
    {
        if (itemtype == ITEMTYPE.USED)
        {
            itemData.Use(player);
            count--;
        }
        else if (itemtype == ITEMTYPE.EQUIPMENT)
        {

        }
        else if (curAmmo>0)
        {
            itemData.Use(player);
            curAmmo--;
        }
    }
    public void Drop(Transform parent)
    {
        itemData.Drop(parent, count);
    }
    public void Reroad(Player player)
    {
        if(itemtype == ITEMTYPE.WEAPON)
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
