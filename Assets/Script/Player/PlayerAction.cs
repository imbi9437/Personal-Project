using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour,IDamagable
{
    private Player player;
    [SerializeField]
    private Transform point;
    [SerializeField]
    private LayerMask targetLayer;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        Interaction();
        ItemUse();
    }

    private void Interaction()
    {
        if(!player.playerInput.InterAction)
            return;

        Collider[] collider = Physics.OverlapSphere(point.position, 1f, targetLayer);
        for (int i = 0; i < collider.Length; i++)
        {
            RaycastHit hit;
            Physics.Raycast(player.playerCamera.transform.position, Vector3.forward, out hit, 3f, targetLayer);
            if (hit.transform.gameObject == collider[i].gameObject)
            {
                IInteratable target = collider[i].GetComponent<IInteratable>();
                target?.Interaction(player);
            }
        }
    }
    private void ItemUse()
    {
        if (!player.playerInput.MouseClick)
            return;
    }
    public void GetDamage(float damage)
    {
        player.Hp -= (damage / player.Def) ;
    }
}
