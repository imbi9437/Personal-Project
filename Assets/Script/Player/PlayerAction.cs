using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour, IDamagable
{
    private Player player;
    [SerializeField]
    private Transform interactionPoint;
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
        InventoryOpen();
    }

    private void Interaction()
    {
        RaycastHit check;
        Physics.SphereCast(player.PlayerCam.transform.position, 0.3f, player.PlayerCam.transform.forward, out check, 1.5f, targetLayer);
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
        if (!player.playerInput.InterAction)
            return;

        Collider[] collider = Physics.OverlapSphere(interactionPoint.position, 1f, targetLayer);
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
    private void ItemUse()
    {
        if (!player.playerInput.MouseClick)
            return;
    }
    private void InventoryOpen()
    {
        if (!Input.GetButtonDown("Inventory"))
            return;
        InventoryManager.instance.playerInventory.SettingInventory(player.Inventory);
    }
    public void GetDamage(float damage)
    {
        player.Hp -= (damage / player.Def);
    }
}
