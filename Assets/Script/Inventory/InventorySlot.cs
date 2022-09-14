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

    public void AddItem(Item item)
    {
        this.item = item;
        itemImage.sprite = item.Image;
        slot.interactable = true;
        if (item.Weight == 1)
        {
            num.text = "";
        }
        else
        {
            
        }

    }
    public void RemoveItem()
    {
        this.item = null;
        slot.interactable = false;

    }
}
