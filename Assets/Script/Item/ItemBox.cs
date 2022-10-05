using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class ItemBox : MonoBehaviour, IInteratable
{
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private int level;
    [SerializeField]
    private GameObject Parachute;
    [SerializeField]
    private ItemFunc itemFist;
    private Inventory inventory;
    private Rigidbody rigidBody;
    private GroundChecker groundChecker;
    private Item item;

    private void Awake()
    {
        itemFist = ItemFunc.instance;
        inventory = GetComponent<Inventory>();
        rigidBody = GetComponent<Rigidbody>();
        groundChecker = GetComponent<GroundChecker>();
        item = new Item();
    }
    private void OnEnable()
    {
        transform.parent = null;
        StartCoroutine(SlowFall());
        StartCoroutine(Setting());

    }
    public void Interaction(Player player)
    {
        CurSceneData.instance.uiChange.interactionSlot.CurMapping = inventory;
        CurSceneData.instance.uiChange.Interaction();
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
            int rarity = level + Random.Range(1, 70);
            rarity = Mathf.Clamp(rarity, 1, 100);
            item = itemFist.ChooseItem(rarity);
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
        yield return new WaitUntil(() => !CurSceneData.instance.uiChange.UiOutside.activeSelf);
        CurSceneData.instance.uiChange.interactionSlot.gameObject.SetActive(false);
        transform.SetParent(parent.transform);
        transform.position = parent.transform.position;
        this.gameObject.SetActive(false);
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
        rigidBody.drag = 2;
    }
    IEnumerator Setting()
    {
        yield return new WaitForSeconds(1f);
        SetItem();
    }
}
