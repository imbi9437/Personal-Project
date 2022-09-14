using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField]
    private InventoryUI[] inventories;
    public class SlotItem
    {
        public Item item;
        public int num;

        public SlotItem(Item item, int num)
        {
            this.item = item;
            this.num = num;
        }
    }

    public Dictionary<string,SlotItem> slotItem = new Dictionary<string, SlotItem>();
    public List<string> slotName = new List<string>();
    public List<SlotItem> slotItems = new List<SlotItem>();


    private void Awake()
    {
        InventoryUpdate();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryActive();
        }
    }

    public void InventoryActive()
    {
        InventoryUpdate();
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
    public void InventoryUpdate()
    {
        for (int i = 0; i < inventories.Length; i++)
        {
            inventories[i].UpdateUI();
        }
    }
    public void AddItem(Item item)
    {
        SlotItem curItem = new SlotItem(item,0);
        slotItem.Add(item.Name,curItem);
        InventoryUpdate();
    }
    public void AddItem(Item item,int num)
    {
        if(FindItem(item))
        {
            slotItem[item.Name].num += num;
        }
        else
        {
            SlotItem curItem = new SlotItem(item,num);
            slotItem.Add(item.Name, curItem);
        }
        InventoryUpdate();
    }
    public void RemoveItem(Item item)
    {
        slotItem.Remove(item.Name);
        InventoryUpdate();
    }
    public void RemoveItem(Item item,int num)
    {
        if (slotItem[item.Name].num<=num)
        {
            slotItem.Remove(item.Name);
        }
        else
        {
            slotItem[item.Name].num -= num;
        }
        InventoryUpdate();
    }
    public bool FindItem(Item item)
    {
        if(slotItem.ContainsKey(item.Name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
