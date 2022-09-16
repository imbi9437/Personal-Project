using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController),(typeof(Animator)))]
public class Zombie : MonoBehaviour
{
    private GameObject airplane;

    private CharacterController characterController;
    private Animator animator;

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
    }
}
