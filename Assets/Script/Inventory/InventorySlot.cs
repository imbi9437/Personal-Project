using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour,IPointerClickHandler,IDragHandler,IEndDragHandler,IBeginDragHandler,IDropHandler,IPointerEnterHandler,IPointerExitHandler
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
        if(item == null)
        {
            slotItem = null;
            image.sprite = empty;
            countText.text = "";
        }
        else if(item.count >0 && item.itemData !=null)
        {
            slotItem = item;
            image.sprite = item.itemData.ItemImage;

            countText.text = "" + item.count;
        }
        else
        {
            slotItem = null;
            image.sprite = empty;
            countText.text = "";
        }
    }
    public void OnPointerClick(PointerEventData eventData) // 클릭이벤트
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(slotItem != null)
            {
                GameManager.instance.player.Inventory.DropItem(slotItem);
            }    
        }
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (slotItem != null)
            {
                slotItem.Use(GameManager.instance.player);
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData) // 드래그 시작 이벤트
    {
        if(slotItem !=null)
        {
            InventoryManager.instance.usingSlot.transform.position = eventData.position;
            InventoryManager.instance.usingSlot.SlotItem = this.slotItem;
            InventoryManager.instance.usingSlot.Image.sprite = slotItem.itemData.ItemImage;
            InventoryManager.instance.usingSlot.CountText.text = slotItem.count.ToString();
            InventoryManager.instance.usingSlot.gameObject.SetActive(true);
        }
    }
    public void OnDrag(PointerEventData eventData) //드래그중 이벤트
    {
        if(slotItem!=null)
        {
            InventoryManager.instance.usingSlot.gameObject.transform.position = eventData.position;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Item item = InventoryManager.instance.usingSlot.SlotItem;
        InventoryManager.instance.usingSlot.gameObject.SetActive(false);
        SetItem(item);
        parentUI.SettingInventory();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Item item = InventoryManager.instance.usingSlot.SlotItem;
        if(slotItem == null&&item != null)
        {
            SetItem(item);
            InventoryManager.instance.usingSlot.SlotItem = null;
        }
        else if(slotItem!=null&&item!=null)
        {
            Item temp = slotItem;
            SetItem(item);
            InventoryManager.instance.usingSlot.SlotItem = temp;
        }
        parentUI.SettingInventory();
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
