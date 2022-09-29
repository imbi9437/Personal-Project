using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField]
    private Player player;
    
    public GameObject curHand;
    public GameObject handItem;

    [SerializeField]
    private GameObject[] hand;
    public GameObject[] Hand { get { return hand; } }

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        CheckCrossHair();
        HandAnimation();
    }
    private void CheckCrossHair()
    {
        if(player.PlayerAction.CurItem.itemData==null||Time.timeScale==0)
        {
            UIManager.instance.crossHair.sprite = UIManager.instance.crossHairImages[0];
            return;
        }
        if(player.PlayerAction.CurItem.itemData.ItemType == ItemData.ITEMTYPE.GUN)
        {
            UIManager.instance.crossHair.sprite = UIManager.instance.curCrossHair;
        }
        else
        {
            UIManager.instance.crossHair.sprite = UIManager.instance.crossHairImages[0];
        }
    }

    private void HandAnimation()
    {
        ItemData itemData = player.PlayerAction.CurItem.itemData;
        if(itemData != null)
        {
            player.Animator.SetInteger("Item", (int)itemData.ItemType);
            player.Animator.SetBool("Hand", true);
            
        }
        else
        {
            player.Animator.SetBool("Hand", false);
            
        }
    }
    
}
