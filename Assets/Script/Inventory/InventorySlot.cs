using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
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
    [SerializeField]
    private Sprite empty;
    public Sprite Empty { get { return empty; } }
    [SerializeField]
    private InventoryUI parentUI;

    public void SetItem(Item item)
    {
        if (item == null)
        {
            slotItem.itemData = null;
            slotItem.count = 0;
            slotItem.curAmmo = 0;
            image.sprite = empty;
            countText.text = "";
        }
        else if (item.itemData == null || item.count <= 0)
        {
            slotItem.itemData = null;
            slotItem.count = 0;
            slotItem.curAmmo = 0;
            image.sprite = empty;
            countText.text = "";
        }
        else
        {
            slotItem.itemData = item.itemData;
            slotItem.count = item.count;
            slotItem.curAmmo = item.curAmmo;
            image.sprite = item.itemData.ItemImage;
            if (item.itemData.ItemType == ItemData.ITEMTYPE.GUN)
            {
                countText.text = "" + item.curAmmo;
            }
            else
            {
                countText.text = "" + item.count;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData) // 클릭이벤트
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (slotItem.itemData != null)
            {
                CurSceneData.instance.player.Inventory.DropItem(slotItem);
            }
        }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (slotItem.itemData != null)
            {
                if (slotItem.itemData.CanUseInventory)
                {
                    slotItem.Use(CurSceneData.instance.player);
                }
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData) // 드래그 시작 이벤트
    {
        if (slotItem.itemData != null)
        {
            CurSceneData.instance.uiChange.usingSlot.SaveData(slotItem);
            CurSceneData.instance.uiChange.usingSlot.transform.position = eventData.position;
            CurSceneData.instance.uiChange.usingSlot.gameObject.SetActive(true);
        }
    }
    public void OnDrag(PointerEventData eventData) //드래그중 이벤트
    {
        if (slotItem.itemData != null)
        {
            CurSceneData.instance.uiChange.usingSlot.gameObject.transform.position = eventData.position;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Item item = CurSceneData.instance.uiChange.usingSlot.SlotItem;
        CurSceneData.instance.uiChange.usingSlot.gameObject.SetActive(false);
        SetItem(item);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Item item = CurSceneData.instance.uiChange.usingSlot.SlotItem;
        if (slotItem.itemData == null && item.itemData != null)
        {
            SetItem(item);
            CurSceneData.instance.uiChange.usingSlot.SaveData();
        }
        else if (slotItem.itemData != null && item.itemData != null)
        {
            Item temp = new Item();
            temp.count = slotItem.count;
            temp.itemData = slotItem.itemData;
            temp.curAmmo = slotItem.curAmmo;
            if (slotItem.itemData != item.itemData)
            {
                SetItem(item);
                CurSceneData.instance.uiChange.usingSlot.SaveData(temp);
            }
            else if (slotItem.itemData == item.itemData)
            {
                if (item.itemData.MaxCount == 1)
                {
                    SetItem(item);
                    CurSceneData.instance.uiChange.usingSlot.SaveData(temp);
                }
                else if (slotItem.count + item.count > item.itemData.MaxCount)
                {
                    CurSceneData.instance.uiChange.usingSlot.SlotItem.count = slotItem.itemData.MaxCount - temp.count;
                    temp.count = item.itemData.MaxCount;
                    SetItem(temp);
                }
                else if (slotItem.count + item.count <= item.itemData.MaxCount)
                {
                    temp.count += item.count;
                    SetItem(temp);
                    CurSceneData.instance.uiChange.usingSlot.SaveData();
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //툴팁 온
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //툴팁 오프
    }
}
