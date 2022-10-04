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
        SetItem();

    }
    public void Interaction(Player player)
    {
        GameManager.instance.curSceneData.uiChange.interactionSlot.CurMapping = inventory;
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
            int rarity = level + Random.Range(1, 50);
            rarity = Mathf.Clamp(rarity, 1, 100);
            item = itemList.ChooseItem(rarity);
            if (item != null)
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
        yield return new WaitUntil(() => !GameManager.instance.curSceneData.uiChange.UiOutside.activeSelf);
        GameManager.instance.curSceneData.uiChange.interactionSlot.gameObject.SetActive(false);
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
}
