using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController),(typeof(Animator)))]
public class Zombie : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    public enum States { Idle, Trace, Attack, Hit, Die }
    private States curstate = States.Idle;
    public States State { get { return curstate; } set { curstate = State; } }

    private float maxHp = 300f;
    public float MaxHP { get { return maxHp; } }
    private float maxDamage = 20f;
    public float MaxDamage { get { return maxDamage; } }

    [SerializeField]
    private LayerMask targetLayer;
    public LayerMask TargetLayer { get { return targetLayer; } }
    [SerializeField, Range(0f, 300f)]
    private float hp;
    public float Hp { get { return hp; } set { hp = value; } }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
}
