using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public abstract class ItemData : ScriptableObject
{
    public enum ITEMTYPE { GUN, SWORD, USED, ARMOR, INGERDIENT }


    [SerializeField]
    private ITEMTYPE itemType;
    public ITEMTYPE ItemType { get { return itemType; } }
    [SerializeField]
    private bool canUseOnClick;
    public bool CanUseOnClick { get { return canUseOnClick; } }
    [SerializeField]
    private bool canUseInventory;
    public bool CanUseInventory { get { return canUseInventory; } }
    [SerializeField]
    protected string itemName;
    public string ItemName { get { return itemName; } }
    [SerializeField]
    protected Sprite itemImage;
    public Sprite ItemImage { get { return itemImage; } }
    [SerializeField]
    protected GameObject itemPrefeb;
    public GameObject ItemPrefeb { get { return itemPrefeb; } }
    [SerializeField]
    protected int maxCount;
    public int MaxCount { get { return maxCount; } }
    [SerializeField]
    private float coolTime;
    public float CoolTime { get { return coolTime; } }

    [SerializeField]
    private AudioClip usingSound;
    public AudioClip UsingSound { get { return usingSound; } }

    //public static Dictionary<string, Action> customFuncDic = new Dictionary<string, Action>();

    public abstract void Use(Player player);

    //public void UseFunc(string funcName)
    //{
    //    if (customFuncDic.ContainsKey(funcName))
    //        customFuncDic[funcName]?.Invoke();
    //}
    public void Drop(Transform value,int count,int ammo)
    {
        Vector3 point = value.position + value.forward + value.up;
        GameObject item = Instantiate(itemPrefeb, point, Quaternion.identity);
        item.GetComponent<ItemController>().Item.count = count;
        item.GetComponent<ItemController>().Item.curAmmo = ammo;
    }
}
