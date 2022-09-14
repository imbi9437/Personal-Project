using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController),(typeof(Animator)))]
public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public Animator animator;
    public PlayerInput playerInput;
    public Camera playerCam;

    [SerializeField,Range(0f,500f)]
    private float hp = 500f;
    public float Hp { get { return hp; } set { hp = value; } }
    [SerializeField]
    private float speed = 10f;
    public float Speed { get { return speed; } }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }
}
