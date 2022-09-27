using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int count;
    public ItemData itemData;

    public void Use(Player player)
    {
        count--;
        itemData.Use(player);
    }
    public void Drop(Transform parent)
    {
        itemData.Drop(parent, count);
    }
}
