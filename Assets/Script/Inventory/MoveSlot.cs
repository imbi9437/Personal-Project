using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveSlot : MonoBehaviour
{
    [SerializeField]
    private Item slotItem;
    public Item SlotItem { get { return slotItem; } set { slotItem = value; } }
    [SerializeField]
    private Image image;
    public Image Image { get { return image; } set { image = value; } }
    [SerializeField]
    private TextMeshProUGUI countText;
    public TextMeshProUGUI CountText { get { return countText; } set { countText = value; } }
    public string itemName;

    private void OnEnable()
    {
        image.sprite = slotItem.itemData.ItemImage;
        countText.text = "" + slotItem.count;
        itemName = slotItem.itemData.ItemName;
    }

    public void SaveData(Item item)
    {
        slotItem.itemData = item.itemData;
        slotItem.count = item.count;
        slotItem.curAmmo = item.curAmmo;
    }
    public void SaveData()
    {
        slotItem.itemData = null;
        slotItem.count = 0;
        slotItem.curAmmo = 0;
    }

}
