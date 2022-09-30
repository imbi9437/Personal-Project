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
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, 2f);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 dirVec = (colliders[i].transform.position - player.transform.position).normalized;
            if (Vector3.Dot(player.transform.forward, dirVec) > Mathf.Cos(60f * 0.5f * Mathf.Deg2Rad))
            {
                IDamagable target = colliders[i].transform.GetComponent<IDamagable>();
                target?.GetDamage(damage);
            }
        }
    }
}
