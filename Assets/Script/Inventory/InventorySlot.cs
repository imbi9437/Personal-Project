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
    private int count;
    public int Count { get { return count; } set { count = value; } }
    [SerializeField]
    private Sprite empty;
    public Sprite Empty { get { return empty; } }

    public void SetItem(Item item)
    {
        if(item.count >0 && item.itemData !=null)
        {
            slotItem = item;
            image.sprite = item.itemData.ItemImage;
            count = item.count;
            countText.text = "" + count;
        }
        else
        {
            slotItem = null;
            image.sprite = empty;
            count = 0;
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
                GetComponentInParent<InventoryUI>().SettingInventory(GameManager.instance.player.Inventory);
            }    
        }
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (slotItem != null)
            {
                slotItem.Use(GameManager.instance.player);
                GetComponentInParent<InventoryUI>().SettingInventory(GameManager.instance.player.Inventory);
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData) // 드래그 시작 이벤트
    {
        //InventoryManager.instance.usingSlot.transform.position = eventData.position;
        //InventoryManager.instance.usingSlot.SlotItem = this.slotItem;
        //InventoryManager.instance.usingSlot.Count = this.count;
        //InventoryManager.instance.usingSlot.Image.sprite = this.image.sprite;
        //InventoryManager.instance.usingSlot.CountText.text = this.countText.text;
        //InventoryManager.instance.usingSlot.gameObject.SetActive(true);
    }
    public void OnDrag(PointerEventData eventData) //드래그중 이벤트
    {
        //InventoryManager.instance.usingSlot.gameObject.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData) // 드래그 종료 이벤트
    {
        //InventoryManager.instance.usingSlot.gameObject.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData) // 드래그 종료 이벤트
    {
        
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
