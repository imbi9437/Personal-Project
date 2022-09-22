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
    [SerializeField]
    private ParticleSystem particle;

    public override void Use()
    {
        Debug.Log("ÃÑ »ç¿ë");
        
    }
}
