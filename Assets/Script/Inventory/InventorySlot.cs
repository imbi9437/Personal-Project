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
            slotItem.itemData = null;
            slotItem.count = 0;
            image.sprite = empty;
            countText.text = "";
        }
        else if(item.itemData == null||item.count<=0)
        {
            slotItem.itemData = null;
            slotItem.count = 0;
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
            countText.text = ""+item.count;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData) // Ŭ���̺�Ʈ
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(slotItem.itemData != null)
            {
                GameManager.instance.curSceneData.player.Inventory.DropItem(slotItem);
            }    
        }
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (slotItem.itemData != null)
            {
                if(slotItem.itemData.CanUseInventory)
                {
                    slotItem.Use(GameManager.instance.curSceneData.player);
                }
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData) // �巡�� ���� �̺�Ʈ
    {
        if(slotItem.itemData !=null)
        {
            GameManager.instance.curSceneData.uiChange.usingSlot.SaveData(slotItem);
            GameManager.instance.curSceneData.uiChange.usingSlot.transform.position = eventData.position;
            GameManager.instance.curSceneData.uiChange.usingSlot.Image.sprite = slotItem.itemData.ItemImage;
            GameManager.instance.curSceneData.uiChange.usingSlot.CountText.text = slotItem.count.ToString();
            GameManager.instance.curSceneData.uiChange.usingSlot.itemName = gameObject.name;
            GameManager.instance.curSceneData.uiChange.usingSlot.gameObject.SetActive(true);
        }
    }
    public void OnDrag(PointerEventData eventData) //�巡���� �̺�Ʈ
    {
        if(slotItem.itemData!=null)
        {
            GameManager.instance.curSceneData.uiChange.usingSlot.gameObject.transform.position = eventData.position;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Item item = GameManager.instance.curSceneData.uiChange.usingSlot.SlotItem;
        GameManager.instance.curSceneData.uiChange.usingSlot.gameObject.SetActive(false);
        SetItem(item);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Item item = GameManager.instance.curSceneData.uiChange.usingSlot.SlotItem;
        if(slotItem.itemData == null&&item.itemData != null)
        {
            SetItem(item);
            GameManager.instance.curSceneData.uiChange.usingSlot.SaveData();
        }
        else if(slotItem.itemData !=null&&item.itemData !=null)
        {
            Item temp = new Item();
            temp.count = slotItem.count;
            temp.itemData = slotItem.itemData;
            temp.curAmmo = slotItem.curAmmo;
            if (slotItem.itemData != item.itemData)
            {
                SetItem(item);
                GameManager.instance.curSceneData.uiChange.usingSlot.SaveData(temp);
            }
            else if (slotItem.itemData == item.itemData)
            {
                if(item.itemData.MaxCount == 1)
                {
                    SetItem(item);
                    GameManager.instance.curSceneData.uiChange.usingSlot.SaveData(temp);
                }
                else if(slotItem.count+item.count>item.itemData.MaxCount)
                {
                    GameManager.instance.curSceneData.uiChange.usingSlot.SlotItem.count = slotItem.itemData.MaxCount-temp.count;
                    temp.count = item.itemData.MaxCount;
                    SetItem(temp);
                }
                else if (slotItem.count+item.count<=item.itemData.MaxCount)
                {
                    if (GameManager.instance.curSceneData.uiChange.usingSlot.itemName != gameObject.name)
                    {
                        temp.count += item.count;
                        SetItem(temp);
                        GameManager.instance.curSceneData.uiChange.usingSlot.SaveData();
                    }
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //���� ��
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //���� ����
    }
}
