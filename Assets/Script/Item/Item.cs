using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour,IInteratable
{
    [SerializeField]
    private int count = 1;
    public int Count { get { return count; } set { count = value; } }
    [SerializeField]
    private ParticleSystem particle;

    [SerializeField]
    private ItemData itemData;
    public ItemData ItemData { get { return itemData; } }

    public void Interaction(Player player)
    {
        player.Inventory.GetItem(this);
        //Destroy(this.gameObject);
    }

    public void OnFoucus()
    {
        particle.Play();
    }

    public void OutFoucus()
    {
        particle.Stop();
    }
    public void Use(Player player)
    {
        itemData.Use(player);
    }
    public void Drop(int value)
    {
        count = value;
        Instantiate(itemData.ItemPrefeb,transform.position,Quaternion.identity);
    }
}
