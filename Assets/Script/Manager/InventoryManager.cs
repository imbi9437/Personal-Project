using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField]
    private InventoryUI[] inventories;
    public class SlotItem
    {
        public Item item;
        public int num;
    }

    public Dictionary<string,SlotItem> slotItem = new Dictionary<string, SlotItem>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryActive();
        }
    }

    public void InventoryActive()
    {
        for (int i = 0; i < inventories.Length; i++)
        {
            if (inventories[0].gameObject.activeSelf ==false)
            {
                Cursor.lockState = CursorLockMode.None;
                inventories[i].gameObject.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                inventories[i].gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item item)
    {
        if (slotItem.ContainsKey(item.Name))
        {

        }
        SlotItem curItem = new SlotItem();
        curItem.item = item;
        curItem.num = 1;
        slotItem.Add(curItem.item.Name,curItem);
    }

    public void RemoveItem(Item item)
    {

    }
}
