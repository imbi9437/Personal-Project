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
    private SlotItem item;
    public SlotItem Item { get { return item; } }
    private Image itemImage;

    private void Awake()
    {
        itemImage = GetComponentInChildren<Image>();
    }

    public void AddItem(SlotItem item,int count)
    {
        this.item = item;
        itemImage.sprite = item.item.Image;
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
        itemImage.sprite = null;
        num.text = "";
    }

    public void RemoveItem(SlotItem item,int num)
    {
        //not yet after testing
    }
    public void Use()
    {
        item.item.Use();
    }
    public void Drop()
    {
        item.item.drop();
    }
}
