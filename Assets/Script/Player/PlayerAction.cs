using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class PlayerAction : MonoBehaviour, IDamagable
{
    private Player player;
    [SerializeField]
    private Transform interactionPoint;
    public Transform InteractionPoint { get { return interactionPoint; } }
    [SerializeField]
    private LayerMask targetLayer;
    public LayerMask TargetLayer { get { return targetLayer; } }
    [SerializeField]
    private Item curItem;
    public Item CurItem { get { return curItem; } }
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        CheckInteraction();
        Interaction();
        ItemUse();
        ChangeQuickSlot(player.QuickSlotNum);
        ReroadItem();
    }

    private void Interaction()
    {
        if (!player.PlayerInput.InterAction)
            return;
        Collider[] collider = Physics.OverlapSphere(interactionPoint.position, 1.5f, targetLayer);
        for (int i = 0; i < collider.Length; i++)
        {
            RaycastHit hit;
            Physics.SphereCast(player.PlayerCam.transform.position, 0.3f, player.PlayerCam.transform.forward, out hit, 2f, targetLayer);
            if (collider[i] == hit.collider)
            {
                IInteratable target = collider[i].GetComponent<IInteratable>();
                target?.Interaction(player);
            }
        }
    }
    private void CheckInteraction()
    {
        RaycastHit check;
        Physics.SphereCast(player.PlayerCam.transform.position, 0.3f, player.PlayerCam.transform.forward, out check, 2f, targetLayer);
        if (check.collider != null)
        {
            IInteratable target = check.collider.GetComponent<IInteratable>();
            if (target != null)
            {
                UIManager.instance.UpdateCheckUI(true);
            }
        }
        else
        {
            UIManager.instance.UpdateCheckUI(false);
        }
    }
    private void ItemUse()
    {
        if (Time.timeScale == 0)
            return;
        if(curItem.itemData == null)
        {
            return;
        }
        if (curItem.itemData.CanUseOnClick)
        {
            if (!player.PlayerInput.MousePush&&!player.PlayerInput.MouseClick)
                return;
        }
        else
        {
            if (!player.PlayerInput.MouseClick)
                return;
        }
        if (!curItem.coolTime)
            return;
        curItem.Use(player);
    }
    private void ReroadItem()
    {
        if(!Input.GetKeyDown(KeyCode.R))
            return;
        if (curItem.itemData == null)
            return;
        if (curItem.itemData.ItemType != ItemData.ITEMTYPE.GUN)
            return;
        curItem.Reroad(player);
    }
    public void Die()
    {
        player.Animator.SetTrigger("Die");
    }
    public void GetDamage(float damage)
    {
        player.Hp -= (damage / player.Def);
    }

    public void ChangeQuickSlot(int value)
    {

        if(curItem == player.QuickSlot.items[value - 1])
        {
            return;
        }
        curItem = player.QuickSlot.items[value - 1];
    }
}
