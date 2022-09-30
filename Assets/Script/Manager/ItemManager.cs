using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
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
