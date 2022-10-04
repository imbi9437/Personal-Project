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
        Interaction();
        ItemUse();
        ChangeQuickSlot(player.QuickSlotNum);
        ReroadItem();
    }

    private void Interaction()
    {
        RaycastHit hit;
        Physics.SphereCast(player.PlayerCam.transform.position, 0.3f, player.PlayerCam.transform.forward, out hit, 2f, targetLayer);
        if(hit.collider == null)
        {
            GameManager.instance.curSceneData.uiChange.CheckOutInteraction(false);
            return;
        }
        else
        {
            IInteratable target = hit.collider.GetComponent<IInteratable>();
            if (target != null)
            {
                GameManager.instance.curSceneData.uiChange.CheckOutInteraction(true);
            }
        }
        if (!InputManager.instance.InterAction)
            return;
        Collider[] collider = Physics.OverlapSphere(interactionPoint.position, 1.5f, targetLayer);
        for (int i = 0; i < collider.Length; i++)
        {
            if (collider[i] == hit.collider)
            {
                IInteratable target = collider[i].GetComponent<IInteratable>();
                target?.Interaction(player);
            }
        }
    }
    private void ItemUse()
    {
        player.Animator.SetBool("Fire", false);
        if (Time.timeScale == 0)
            return;
        if(curItem.itemData == null)
        {
            return;
        }
        if (curItem.itemData.CanUseOnClick)
        {
            if (!InputManager.instance.MousePush&&!InputManager.instance.MouseLeftClick)
                return;
        }
        else
        {
            if (!InputManager.instance.MouseLeftClick)
                return;
        }
        if (!curItem.coolTime)
            return;
        if (curItem.count <= 0)
            return;
        if (curItem.itemData.ItemType == ItemData.ITEMTYPE.GUN && curItem.curAmmo <= 0)
            return;
        player.Animator.SetBool("Fire", true);
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
        player.AudioSource.clip = player.PlayerAudio[1];
        player.AudioSource.Play();
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
