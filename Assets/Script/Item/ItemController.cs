using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour, IInteratable
{
    [SerializeField]
    private Item item;
    public Item Item { get { return item; } set { item = value; } }

    public void Interaction(Player target)
    {
        target.Inventory.GetItem(item);
        Destroy(this.gameObject);
    }

    public void OnFoucus()
    {
        
    }

    public void OutFoucus()
    {
        
    }
    public void Use(Player player)
    {
        item.Use(player);
    }
}
