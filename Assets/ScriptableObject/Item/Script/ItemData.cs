using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public enum ITEMTYPE { USED, ARMOR, GUN, SWORD, INGERDIENT}

    [SerializeField]
    private ITEMTYPE itemType;
    public ITEMTYPE ItemType { get { return itemType; } }
    [SerializeField]
    private bool canUseOnClick;
    public bool CanUseOnClick { get { return canUseOnClick; } }
    [SerializeField]
    private bool canuseInventory;
    public bool CanUseInventory { get { return canuseInventory; } }
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

    public abstract void Use(Player player);
    public void Drop(Transform value,int count)
    {
        Vector3 point = value.position + value.forward + value.up;
        GameObject item = Instantiate(itemPrefeb, point, Quaternion.identity);
        item.GetComponent<ItemController>().Item.count = count;
    }
}
