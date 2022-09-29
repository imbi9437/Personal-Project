using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBox : MonoBehaviour, IInteratable
{
    [SerializeField]
    private int level;
    [SerializeField]
    private GameObject Parachute;
    private Inventory inventory;
    private Rigidbody rigidBody;
    private GroundChecker groundChecker;
    private Item item;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        rigidBody = GetComponent<Rigidbody>();
        groundChecker = GetComponent<GroundChecker>();
        item = new Item();
    }
    private void OnEnable()
    {
        StartCoroutine(SlowFall());
        StartCoroutine(SetItemCo());
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
        for (int i = 0; i < inventory.items.Length; i++)
        {
            int rarity = level + Random.Range(0, 100);
            rarity = Mathf.Clamp(rarity, 0, 100);
            item.itemData = ItemManager.instance.ChooseItem(rarity).itemData;
            item.count = ItemManager.instance.ChooseItem(rarity).count;
            item.curAmmo = ItemManager.instance.ChooseItem(rarity).curAmmo;
            if (item.itemData != null)
            {
                inventory.items[i].itemData = item.itemData;
                inventory.items[i].count = Random.Range(0, item.itemData.MaxCount + 1);
                inventory.items[i].curAmmo = item.curAmmo;
            }
            else
            {
                continue;
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
    IEnumerator SlowFall()
    {
        rigidBody.drag = 5;
        if(!groundChecker.isGround)
        {
            Parachute.SetActive(true);
        }
        yield return new WaitUntil(() => groundChecker.isGround);
        Parachute.SetActive(false);
        rigidBody.drag = 0;
    }
    IEnumerator SetItemCo()
    {
        yield return new WaitForSeconds(2f);
        SetItem();
    }
}
