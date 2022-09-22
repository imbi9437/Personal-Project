using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
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

    public abstract void Use();
}
