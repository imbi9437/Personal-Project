using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController),(typeof(Animator)))]
public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    public CharacterController characterController { get; set; }
    private Animator _animator;
    public Animator animator { get; set; }
    private PlayerInput _playerInput;
    public PlayerInput playerInput { get; set; }
    private PlayerAction playerAction;
    public PlayerAction PlayerAction { get; set; }
    [SerializeField]
    private Camera playerCam;
    public Camera PlayerCam { get { return playerCam; } set { playerCam = value; } }
    private GroundChecker _playerGroundChecker;
    public GroundChecker playerGroundChecker { get; set; }
    private SoundGenerator playerSoundGenerator;
    public SoundGenerator PlayerSoundGenerator { get { return playerSoundGenerator; } set { playerSoundGenerator = value; } } // 에러나는 이유 질문
    private Inventory inventory;
    public Inventory Inventory 
    {
        get { return inventory; } 
        set 
        {
            inventory = value;
            InventoryManager.instance.playerInventory.SettingInventory(inventory);
        } 
    }

    [SerializeField,Range(0f,500f)]
    private float hp = 500f;
    public float Hp { get { return hp; } set { hp = value; } }
    [SerializeField]
    private float speed = 10f;
    public float Speed { get { return speed; } }
    [SerializeField]
    private float def;
    public float Def { get { return def; } set { def = value; } }
    [SerializeField,Range(0f,200f)]
    private float mouseSensitive;
    public float MouseSensitive { get { return mouseSensitive; } }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerAction = GetComponent<PlayerAction>();
        playerGroundChecker = GetComponent<GroundChecker>();
        playerSoundGenerator = GetComponent<SoundGenerator>();
        inventory = GetComponent<Inventory>();
    }
}
