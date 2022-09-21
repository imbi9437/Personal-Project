using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController),(typeof(Animator)))]
public class Zombie : MonoBehaviour
{
    public enum States { Fall, Idle, Trace, Attack, Hit, Die}

    [SerializeField]
    private GameObject airplane;
    public GameObject Airplane { get { return airplane; } }
    private CharacterController characterController;
    public CharacterController CharacterController { get { return characterController; } }
    private Animator animator;
    public Animator Animator { get { return animator; } }
    private ZombieAction zombieAction;
    public ZombieAction ZombieAction { get { return zombieAction; } set { zombieAction = value; } }
    private FindTarget findTarget;
    public FindTarget FindTarget { get { return findTarget; } set { findTarget = value; } }
    private GroundChecker groundChecker;
    public GroundChecker GroundChecker { get { return groundChecker; } }

    private float maxHp;
    public float MaxHp { get { return maxHp; } set { maxHp = value; } }
    private float curHp;
    public float CurHp { get { return curHp; } set { curHp = value; } }
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
    private float hp;
    public float Hp { get { return hp; } set { hp = value; } }
    private float maxDamage;
    public float MaxDamage { get { return maxDamage; } set { maxDamage = value; } }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        groundChecker = GetComponent<GroundChecker>();
        maxHp = 300f;
        maxDamage = 20f;
    }
}
