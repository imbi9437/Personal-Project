using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), (typeof(Animator)))]
public class Player : MonoBehaviour
{
    private CharacterController characterController;
    public CharacterController CharacterController { get { return characterController; } set { characterController = value; } }
    private Animator animator;
    public Animator Animator { get { return animator; } set { animator = value; } }
    private PlayerAction playerAction;
    public PlayerAction PlayerAction { get { return playerAction; } set { playerAction = value; } }
    private PlayerHand playerHand;
    public PlayerHand PlayerHand { get { return playerHand; } set { playerHand = value; } }
    private AudioSource audioSource;
    public AudioSource AudioSource { get { return audioSource; } set { audioSource = value; } }
    private Camera playerCam;
    public Camera PlayerCam { get { return playerCam; } set { playerCam = value; } }
    private GroundChecker playerGroundChecker;
    public GroundChecker PlayerGroundChecker { get { return playerGroundChecker; } set { playerGroundChecker = value; } }
    private SoundGenerator playerSoundGenerator;
    public SoundGenerator PlayerSoundGenerator { get { return playerSoundGenerator; } set { playerSoundGenerator = value; } }
    [SerializeField]
    private Inventory inventory;
    public Inventory Inventory { get { return inventory; } set { inventory = value; } }
    [SerializeField]
    private Inventory quickSlot;
    public Inventory QuickSlot { get { return quickSlot; }set { quickSlot = value; } }


    private int quickSlotNum = 1;
    public int QuickSlotNum { get { return quickSlotNum; } set { quickSlotNum = value; QuickSlotChange(quickSlotNum); } }

    [SerializeField]
    private AudioClip[] playerAudio;
    public AudioClip[] PlayerAudio { get { return playerAudio; } set { playerAudio = value; } }

    public Action<float> StatusUpdate;
    public Action<int> QuickSlotChange;

    private const float maxHp = 500f;
    [SerializeField]
    private float hp;
    public float Hp 
    { 
        get
        { return hp; }
        set 
        { 
            hp = value;
            if (hp > maxHp)
            { 
                hp = maxHp;
            }
            else if (hp<=0)
            {
                PlayerAction.Die();
                return;
            }
            StatusUpdate(hp);
        }
    }
    [SerializeField]
    private float speed = 10f;
    public float Speed { get { return speed; } }
    [SerializeField]
    private float def;
    public float Def { get { return def; } set { def = value; } }
    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
        playerAction = GetComponent<PlayerAction>();
        PlayerGroundChecker = GetComponent<GroundChecker>();
        playerSoundGenerator = GetComponent<SoundGenerator>();
        playerHand = GetComponent<PlayerHand>();
        audioSource = GetComponent<AudioSource>();
        playerCam = GetComponentInChildren<Camera>();
        hp = maxHp;
        
    }
}
