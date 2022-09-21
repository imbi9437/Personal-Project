using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="ScriptableObject/Item/Weapon")]
public class Weapon : ItemData
{
    public enum weaponType { Gun, Melee }
    public weaponType itemType;
    [SerializeField]
    private float damage;
    public float Damage { get { return damage; } }
}
