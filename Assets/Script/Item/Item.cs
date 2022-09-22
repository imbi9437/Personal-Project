using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour,IInteratable
{
    [SerializeField]
    private int count;
    public int Count { get { return count; } set { count = value; } }
    [SerializeField]
    private ParticleSystem particle;
    private Animator animator;

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
        itemData.Use();
    }
    public void Drop(int value)
    {
        
    }
}
