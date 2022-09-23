using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour,IPointerClickHandler,IDragHandler,IEndDragHandler,IBeginDragHandler,IDropHandler
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

    public void SetItem(Item item)
    {
        slotItem = item;
        image.sprite = item.ItemData.ItemImage;
        count = item.Count;
        countText.text = ""+count;
    }
    public void AddItem(Item item,int value)
    {
        if(slotItem !=null)
        {
            count += value;
            countText.text = ""+count;
        }
        else
        {
            slotItem = item;
            count = value;
            image.sprite = item.ItemData.ItemImage;
            image.gameObject.SetActive(true);
            countText.text = ""+count;
        }
    }
    public void RemoveItem(int value)
    {
        if(count==value)
        {
            countText.text = "";
            count = 0;
            image.sprite = null;
            image.gameObject.SetActive(false);
            slotItem = null;
        }
        else if (count>value)
        {
            count -= value;
            countText.text = "" + count;
        }
    }
    public void ChangeItem(Item item, int value)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("아이템 정보");
            //아이템 정보 띄우기
        }
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("아이템 이동");
            //아이템 퀵슬롯 이동 또는 장비창 이동
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        InventoryManager.instance.usingSlot.transform.position = eventData.position;
        InventoryManager.instance.usingSlot.SlotItem = this.slotItem;
        InventoryManager.instance.usingSlot.Count = this.count;
        InventoryManager.instance.usingSlot.Image.sprite = this.image.sprite;
        InventoryManager.instance.usingSlot.CountText.text = this.countText.text;
        InventoryManager.instance.usingSlot.gameObject.SetActive(true);
    }
    public void OnDrag(PointerEventData eventData)
    {
        InventoryManager.instance.usingSlot.gameObject.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        InventoryManager.instance.usingSlot.gameObject.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
