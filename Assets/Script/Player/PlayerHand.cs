using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private AudioSource itemSound;
    public AudioSource ItemSound { get { return ItemSound; } set { itemSound = value; } }
    
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
        ChangeCurHand();
        CheckCrossHair();
        //HandAnimation();
    }
    private void CheckCrossHair()
    {
        if(player.PlayerAction.CurItem.itemData==null||Time.timeScale==0)
        {
            CurSceneData.instance.uiChange.crossHair.sprite = SettingManager.instance.crossHair[0];
            return;
        }
        if(player.PlayerAction.CurItem.itemData.ItemType == ItemData.ITEMTYPE.GUN)
        {
            CurSceneData.instance.uiChange.crossHair.sprite = SettingManager.instance.curCrossHair;
        }
        else
        {
            CurSceneData.instance.uiChange.crossHair.sprite = SettingManager.instance.crossHair[0];
        }
    }
    private void HandAnimation()
    {
        ItemData itemData = player.PlayerAction.CurItem.itemData;
        if(itemData != null)
        {
            if(itemData.ItemType == ItemData.ITEMTYPE.GUN)
            {
                Gun item = (Gun)itemData;
                if((int)item.GunType<=3)
                {
                    player.Animator.SetTrigger("Rifle");
                }
                else
                {
                    player.Animator.SetTrigger("Other");
                }
            }
            player.Animator.SetInteger("Item", (int)itemData.ItemType);
            player.Animator.SetBool("Hand", true);
            
        }
        else
        {
            player.Animator.SetBool("Hand", false);
            
        }
    }
    public void SetClip(AudioClip clip)
    {
        if (itemSound.clip == clip)
        {
            itemSound.Play();
        }
        else
        {
            itemSound.clip = clip;
            itemSound.Play();
        }
    }

    private void ChangeCurHand()
    {
        if(InputManager.instance.Alpha1)
        {
            player.QuickSlotNum = 1;
        }
        if (InputManager.instance.Alpha2)
        {
            player.QuickSlotNum = 2;
        }
        if (InputManager.instance.Alpha3)
        {
            player.QuickSlotNum = 3;
        }
        if (InputManager.instance.Alpha4)
        {
            player.QuickSlotNum = 4;
        }
        if (InputManager.instance.Alpha5)
        {
            player.QuickSlotNum = 5;
        }
        if (InputManager.instance.Alpha6)
        {
            player.QuickSlotNum = 6;
        }
    }

}
