using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Item/Weapon/Gun")]
public class Gun : Weapon
{
    public enum GUNTYPE { AssaltRifle, HeavyMachine, Shotgun, VoltActionRifle, HandGun }

    [SerializeField]
    private GUNTYPE gunType;
    public GUNTYPE GunType { get { return gunType; } }
    [SerializeField]
    private int maxMagazine;
    public int MaxMagazine { get { return maxMagazine; } }
    [SerializeField]
    private Used needAmmo;
    public Used NeedAmmo { get { return needAmmo; } }

    //public Gun()
    //{
    //    if(customFuncDic.ContainsKey("Reload") == false)
    //        customFuncDic.Add("Reload", () => { ; });
    //}

    public override void Use(Player player)
    {
     
        Shoot(player);
     
    }
    private void Shoot(Player player)
    {
        RaycastHit hit;
        if (Physics.Raycast(player.PlayerCam.transform.position, player.PlayerCam.transform.forward, out hit, Mathf.Infinity))
        {
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.GetDamage(needAmmo.damage);
        }
    }

}
