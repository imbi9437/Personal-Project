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
    [SerializeField]
    private ItemList itemList;
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
        transform.parent = null;
        itemList = GameObject.Find("ItemList").GetComponent<ItemList>();
        StartCoroutine(SlowFall());
        StartCoroutine(SetItemCo());

    }
    public void Interaction(Player player)
    {
        InventoryManager.instance.interactionSlot.CurMapping = inventory;
        
        //UIManager.instance.InteractionUImanage();
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
            item.itemData = itemList.ChooseItem(rarity).itemData;
            item.count = itemList.ChooseItem(rarity).count;
            item.curAmmo = itemList.ChooseItem(rarity).curAmmo;
            if (item.itemData != null)
            {
                inventory.items[i].itemData = item.itemData;
                inventory.items[i].count = Random.Range(0, item.itemData.MaxCount/4 + 1);
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
        //yield return new WaitUntil(() => !GameManager.instance.curSceneData.uiChange.ui[2].activeSelf);
        InventoryManager.instance.interactionSlot.gameObject.SetActive(false);
        yield return new WaitForSeconds(10f);
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
