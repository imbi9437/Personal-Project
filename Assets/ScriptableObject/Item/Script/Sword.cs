using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Item/Weapon/Sword")]
public class Sword : Weapon
{
    [SerializeField]
    private float damage;
    public float Damage { get { return damage; } }
    public override void Use(Player player)
    {
        
    }
}
