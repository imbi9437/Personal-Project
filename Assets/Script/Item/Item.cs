using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour,IInteratable
{
    private int count;
    public int Count { get { return count; } set { count = value; } }
    private ParticleSystem particle;

    [SerializeField]
    private ItemData itemData;
    public ItemData ItemData { get { return itemData; } }

    public void Interaction(Player player)
    {
        //æ∆¿Ã≈€ »πµÊ
    }

    public void OnFoucus()
    {
        particle.Play();
    }

    public void OutFoucus()
    {
        particle.Stop();
    }
    public void Use()
    {

    }
    public void Drop(int value)
    {
        
    }
}
