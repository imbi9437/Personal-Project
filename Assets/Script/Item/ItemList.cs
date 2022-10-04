using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public static ItemList instance;


    public Item[] normalItems;
    public Item[] rareItems;
    public Item[] uniqeItems;
    public Item[] legenderyItems;

    private void Awake()
    {
        instance = this;
    }
    public Item ChooseItem(int rarity)
    {
        if (rarity == 100)
        {
            return legenderyItems[Random.Range(0, legenderyItems.Length)];
        }
        else if (rarity >= 90)
        {
            return uniqeItems[Random.Range(0, uniqeItems.Length)];
        }
        else if (rarity >= 70)
        {
            return rareItems[Random.Range(0, rareItems.Length)];
        }
        else if (rarity >= 30)
        {
            return normalItems[Random.Range(0, normalItems.Length)];
        }
        else if (rarity < 30)
        {
            return null;
        }
        return null;
    }
}
