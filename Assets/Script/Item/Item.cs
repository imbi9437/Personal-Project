using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int count;
    public ItemData itemData;
    public int curAmmo;
    public bool coolTime = true;

    public void Use(Player player)
    {
        switch (itemData.ItemType)
        {
            case ItemData.ITEMTYPE.USED:
                if (count > 0)
                {
                    player.PlayerHand.SetClip(itemData.UsingSound);
                }
                itemData.Use(player);
                count--;
                break;
            case ItemData.ITEMTYPE.ARMOR:
                break;
            case ItemData.ITEMTYPE.GUN:
                if (curAmmo > 0)
                {
                    itemData.Use(player);
                    player.PlayerHand.SetClip(itemData.UsingSound);
                    curAmmo--;
                }
                break;
            case ItemData.ITEMTYPE.SWORD:
                itemData.Use(player);
                player.PlayerHand.SetClip(itemData.UsingSound);
                break;
        }

        ItemFunc.instance.StartCoolTime(this);
    }
    public void Drop(Transform parent)
    {
        itemData.Drop(parent, count, curAmmo);
    }
    public void Reroad(Player player)
    {
        if (itemData.ItemType != ItemData.ITEMTYPE.GUN)
        {
            return;
        }
        Gun gundata = (Gun)itemData;
        for (int i = 0; i < player.Inventory.items.Length; i++)
        {
            if (player.Inventory.items[i].itemData != gundata.NeedAmmo)
            {
                continue;
            }

            if (player.Inventory.items[i].count + curAmmo >= gundata.MaxMagazine)
            {
                player.Inventory.items[i].count -= gundata.MaxMagazine - curAmmo;
                curAmmo = gundata.MaxMagazine;
                return;
            }
            else
            {
                curAmmo += player.Inventory.items[i].count;
                player.Inventory.items[i].itemData = null;
                player.Inventory.items[i].count = 0;
            }

        }
        for (int i = 0; i < player.QuickSlot.items.Length; i++)
        {
            if (player.QuickSlot.items[i].itemData != gundata.NeedAmmo)
            {
                continue;
            }

            if (player.QuickSlot.items[i].count + curAmmo >= gundata.MaxMagazine)
            {
                player.QuickSlot.items[i].count -= gundata.MaxMagazine - curAmmo;
                curAmmo = gundata.MaxMagazine;
                return;
            }
            else
            {
                curAmmo += player.QuickSlot.items[i].count;
                player.QuickSlot.items[i].itemData = null;
                player.QuickSlot.items[i].count = 0;
            }
        }
    }
}
