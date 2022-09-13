using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController),(typeof(Animator)))]
public class Zombie : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    private StateMachine<States, Zombie> stateMachine;

    public enum States { Idle, Trace, Attack, Hit, Die }

    private float maxHp = 300f;
    public float MaxHP { get { return maxHp; } }
    private float maxDamage = 20f;
    public float MaxDamage { get { return maxDamage; } }

    [SerializeField]
    private LayerMask targetLayer;
    public LayerMask TargetLayer { get { return targetLayer; } }
    [SerializeField]
    private GameObject target;
    public GameObject Target { get { return target; } set { target = value; } }
    [SerializeField, Range(0f, 300f)]
    private float hp;
    public float Hp { get { return hp; } set { hp = value; } }
    [SerializeField, Range(0f, 10f)]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        stateMachine = new StateMachine<States, Zombie>(this);
        stateMachine.AddState(States.Idle, new ZombieStates.Idle());
        stateMachine.AddState(States.Trace, new ZombieStates.Trace());
        stateMachine.AddState(States.Attack, new ZombieStates.Attack());
        stateMachine.AddState(States.Hit, new ZombieStates.Hit());
        stateMachine.AddState(States.Die, new ZombieStates.Die());

        stateMachine.ChangeState(States.Idle);
    }
    private void Update()
    {
        stateMachine.Update();
    }

    public void ChangeState(States nextState)
    {
        stateMachine.ChangeState(nextState);
    }
}
