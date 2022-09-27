using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveSlot : MonoBehaviour,IDropHandler
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

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
    }
}
