using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        rigidBody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        SetItem();
        StartCoroutine("SlowFall");
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
            int rarity = level + Random.Range(0, 100);
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
    IEnumerator SlowFall()
    {
        rigidBody.drag = 5;
        if(!groundChecker.isGround)
        {
            Parachute.SetActive(true);
        }
        yield return new WaitUntil(() => groundChecker.isGround);
        rigidBody.drag = 0;
    }
}
