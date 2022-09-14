using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Button slot;
    [SerializeField]
    private TextMeshProUGUI num;
    private Item item;
    private Image itemImage;

    private void Awake()
    {
        itemImage = GetComponentInChildren<Image>();
    }

    public void AddItem(Item item,int count)
    {
        this.item = item;
        itemImage.sprite = item.Image;
        slot.interactable = true;
        if(count ==0)
        {
            num.text = "";
        }
        else
        {
            num.text = count.ToString();
        }
    }
    public void RemoveItem()
    {
        this.item = null;
        slot.interactable = false;
        num.text = "";
    }

    public void RemoveItem(Item item,int num)
    {
        //not yet after testing
    }
    public void Use()
    {
        item.Use();
    }
    public void Drop()
    {
        item.drop();
    }
}
