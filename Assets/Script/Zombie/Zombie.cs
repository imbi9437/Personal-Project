using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController),(typeof(Animator)),typeof(AudioSource))]
public class Zombie : MonoBehaviour
{
    public enum States { Fall, Idle, Trace, Attack, Hit, Die}

    [SerializeField]
    private GameObject airplaneDrop;
    public GameObject AirplaneDrop { get { return airplaneDrop; } }
    [SerializeField]
    private GameObject[] zombieChar;
    public GameObject[] ZombieChar { get { return zombieChar; } }
    [SerializeField]
    private GameObject itemBox;
    public GameObject ItemBox { get { return itemBox; } }
    private CharacterController characterController;
    public CharacterController CharacterController { get { return characterController; } }
    private Animator animator;
    public Animator Animator { get { return animator; } }
    private AudioSource zombieAudio;
    public AudioSource ZombieAudio { get { return zombieAudio; } set { zombieAudio = value; } }
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

    public AudioClip[] zombieSound;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        groundChecker = GetComponent<GroundChecker>();
        zombieAudio = GetComponent<AudioSource>();
        zombieAction = GetComponent<ZombieAction>();
        findTarget = GetComponent<FindTarget>();
        maxHp = 300f;
        maxDamage = 40f;
    }
}
