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
    private Camera _playerCam;
    public Camera playerCamera { get; set; }
    private GroundChecker _playerGroundChecker;
    public GroundChecker playerGroundChecker { get; set; }

    [SerializeField,Range(0f,500f)]
    private float hp = 500f;
    public float Hp { get { return hp; } set { hp = value; } }
    [SerializeField]
    private float speed = 10f;
    public float Speed { get { return speed; } }
    [SerializeField,Range(0f,200f)]
    private float mouseSensitive;
    public float MouseSensitive { get { return mouseSensitive; } }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerGroundChecker = GetComponent<GroundChecker>();
    }
}
