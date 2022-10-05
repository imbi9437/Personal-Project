using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunc : MonoBehaviour
{
    public static ItemFunc instance;


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
