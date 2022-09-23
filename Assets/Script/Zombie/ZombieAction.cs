using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Timeline;

public class ZombieAction : MonoBehaviour,IDamagable
{
    [SerializeField]
    private Transform point;
    private Zombie zombie;
    private bool isDelay = false;
    public bool IsDelay { get { return isDelay; } }
    
    private StateMachine<Zombie.States, Zombie> stateMachine;

    private void Awake()
    {
        zombie = GetComponent<Zombie>();
        stateMachine = new StateMachine<Zombie.States, Zombie>(zombie);
        stateMachine.AddState(Zombie.States.Fall, new ZombieStates.FallState());
        stateMachine.AddState(Zombie.States.Idle, new ZombieStates.IdleState());
        stateMachine.AddState(Zombie.States.Trace, new ZombieStates.TraceState());
        stateMachine.AddState(Zombie.States.Attack, new ZombieStates.AttackState());
        stateMachine.AddState(Zombie.States.Hit, new ZombieStates.HitState());
        stateMachine.AddState(Zombie.States.Die, new ZombieStates.DieState());
    }
    private void OnEnable()
    {
        ChangeChar();
        transform.parent = null;
        zombie.Hp = Random.Range(10, zombie.MaxHp);
        zombie.CurHp = zombie.Hp;
        zombie.Speed = Random.Range(1f, 3f);
        stateMachine.ChangeState(Zombie.States.Fall);
    }
    private void Update()
    {
        stateMachine.Update();
        Gravity();
    }
    
    private void Gravity()
    {
        if(!zombie.GroundChecker.isGround)
        {
            zombie.CharacterController.Move(Vector3.up * Physics.gravity.y * Time.deltaTime);
        }
    }
    public void ChangeState(Zombie.States state)
    {
        stateMachine.ChangeState(state);
    }
    public void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(point.position, 1f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject==zombie.FindTarget.Target)
            {
                IDamagable damagable = colliders[i].GetComponent<IDamagable>();
                Player player = colliders[i].GetComponent<Player>();
                damagable?.GetDamage(Random.Range(5f,zombie.MaxDamage));
                if(player !=null&&player.Hp<=0)
                {
                    zombie.Animator.SetTrigger("Kill");
                }
            }
        }
        TimeDelay(4f);
    }
    public void GetDamage(float damage)
    {
        zombie.Hp -= damage;
    }
    public void ChangeChar()
    {
        for (int i = 0; i < zombie.ZombieChar.Length; i++)
        {
            zombie.ZombieChar[i].SetActive(false);
        }
        zombie.ZombieChar[Random.Range(0,zombie.ZombieChar.Length)].SetActive(true);
    }
    public void TimeDelay(float value)
    {
        StartCoroutine(Delay(value));
    }
    IEnumerator Delay(float value)
    {
        isDelay = true;
        yield return new WaitForSeconds(value);
        isDelay = false;
    }

}
