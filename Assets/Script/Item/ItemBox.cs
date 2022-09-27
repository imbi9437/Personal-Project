using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBox : MonoBehaviour, IInteratable
{
    [SerializeField]
    private int level;
    private Animator animator;
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    private void OnEnable()
    {
        SetItem();

    }
    public void Interaction(Player player)
    {
        InventoryManager.instance.interactionSlot.CurMapping = inventory;
        UIManager.instance.InteractionUImanage();
        StartCoroutine(DestroyInteractionBox());
    }

    public void OnFoucus()
    {
        
    }

    public void OutFoucus()
    {
        
    }
    public void SetItem()
    {
        int itemCount = Random.Range(0, inventory.SlotCount);
        for (int i = 0; i < itemCount; i++)
        {
            int rarity = level + Random.Range(0, 101);
            rarity = Mathf.Clamp(rarity, 0, 100);
            Item item = ItemManager.instance.ChooseItem(rarity);
            if(item == null)
            {
                continue;
            }
            else
            {
                inventory.items[i].itemData = item.itemData;
                inventory.items[i].count = Random.Range(0, item.itemData.MaxCount + 1);
            }
        }
    }
    IEnumerator DestroyInteractionBox()
    {
        yield return new WaitUntil(() => !UIManager.instance.UI[2].activeSelf);
        yield return new WaitForSeconds(10f);
        InventoryManager.instance.interactionSlot.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
    IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(120f);
        InventoryManager.instance.interactionSlot.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
