using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Item/Weapon/Gun")]
public class Gun : Weapon
{
    public enum GunType { AssaltRifle, HandGun, Shotgun, VoltActionRifle, HeavyMachine}

    [SerializeField]
    private GunType gunType;
    [SerializeField]
    private int MaxMagazine;
    [SerializeField]
    private Item needAmmo;


    public override void Use(Player player)
    {
        RaycastHit hit;
        if(Physics.Raycast(itemPrefeb.transform.position,Vector3.forward,out hit,Mathf.Infinity))
        {
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.GetDamage(10f);
            itemPrefeb.GetComponent<Weapon>();
        }
    }
}
