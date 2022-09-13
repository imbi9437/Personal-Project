using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController),(typeof(Animator)))]
public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    [SerializeField,Range(0f,500f)]
    private float hp = 500f;
    public float Hp { get { return hp; } set { hp = value; } }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
}
