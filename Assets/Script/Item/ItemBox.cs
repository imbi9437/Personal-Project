using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour, IInteratable
{
    private ParticleSystem particle;
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    public void Interaction(Player player)
    {
        InventoryManager.instance.interactionSlot.SettingInventory(inventory);
    }

    public void OnFoucus()
    {
        particle.Play();
    }

    public void OutFoucus()
    {
        particle.Stop();
    }
}
