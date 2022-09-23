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
        //������ ȹ��
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
