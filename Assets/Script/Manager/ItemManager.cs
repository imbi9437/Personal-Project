using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public Item[] normalItems;
    public Item[] rareItems;
    public Item[] uniqeItems;
    public Item[] legenderyItems;

    public Item ChooseItem(int rarity)
    {
        if(rarity ==100)
        {
            return legenderyItems[Random.Range(0, legenderyItems.Length)];
        }
        else if(rarity>=90)
        {
            return uniqeItems[Random.Range(0, uniqeItems.Length)];
        }
        else if(rarity>=70)
        {
            return rareItems[Random.Range(0, rareItems.Length)];
        }
        else if (rarity>=0)
        {
            return normalItems[Random.Range(0, normalItems.Length)];
        }
        return null;
    }
    public void StartCoolTime(Item item)
    {
        StartCoroutine(CoolTime(item));
    }
    IEnumerator CoolTime(Item item)
    {
        item.coolTime = false;
        yield return new WaitForSeconds(item.itemData.CoolTime);
        item.coolTime = true;
    }
}
