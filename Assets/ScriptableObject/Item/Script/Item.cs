using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField]
    protected string name;
    public string Name { get { return name; } }
    [SerializeField]
    protected Sprite image;
    public Sprite Image { get { return image; } }
    [SerializeField]
    protected GameObject model;
    public GameObject Model { get { return model; } }
    [SerializeField]
    protected int weight;
    public int Weight { get { return weight; } }

    public abstract void Use();
    public void drop()
    {
        Debug.Log("아이템 드롭");
    }
}
