using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="ScriptableObject/Item/Weapon")]
public class Weapon : Item
{
    [SerializeField]
    private float damage;
    public float Damage { get { return damage; } }
    public override void Use()
    {
        Debug.Log("무기 사용");
    }
}
