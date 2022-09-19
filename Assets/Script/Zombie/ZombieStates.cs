using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieStates : MonoBehaviour
{
    public class BaseState : State<Zombie>
    {
        public override void Enter(Zombie owner)
        {
            
        }
        public override void Exit(Zombie owner)
        {
            
        }
        public override void Update(Zombie owner)
        {
            if(owner.Hp<=0)
            {
                ChangeState(owner, Zombie.States.Die);
            }
            if (owner.CurHp < owner.Hp)
            {
                ChangeState(owner, Zombie.States.Hit);
            }
        }
        public void ChangeState(Zombie owner,Zombie.States state)
        {
            owner.ZombieAction.ChangeState(state);
        }
    }
    public class FallState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.Animator.SetBool("Fall", true);
        }
        public override void Update(Zombie owner)
        {
            if(Physics.Raycast(owner.GroundChecker.Point.position,Vector3.down,0.9f))
            {
                owner.Animator.SetBool("Fall", false);
                ChangeState(owner, Zombie.States.Idle);
            }
        }
        public override void Exit(Zombie owner)
        {
            
        }
    }
    public class IdleState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);
            //타겟 추적
            if(owner.Target !=null)
            {
                ChangeState(owner, Zombie.States.Trace);
            }
        }
        public override void Exit(Zombie owner)
        {

        }
    }
    public class TraceState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.Animator.SetBool("Trace", true);
            owner.Animator.SetFloat("Speed",owner.Speed);
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);
            float distance = Vector3.Distance(owner.transform.position, owner.Target.transform.position);
            if (distance > 50f)
            {
                owner.Target = null;
                ChangeState(owner, Zombie.States.Idle);
            }
            else if(distance>0&&distance<2f)
            {
                ChangeState(owner, Zombie.States.Attack);
            }

        }
        public override void Exit(Zombie owner)
        {

        }
    }
    public class AttackState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.Animator.SetInteger("Attacktype", Random.Range(0, 2));
            owner.Animator.SetTrigger("Attack");
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);
            float distance = Vector3.Distance(owner.transform.position, owner.Target.transform.position);
            if(distance > 50f)
            {
                owner.Target = null;
                ChangeState(owner, Zombie.States.Idle);
            }
            else
            {
                ChangeState(owner, Zombie.States.Trace);
            }
        }
        public override void Exit(Zombie owner)
        {
            //데미지 주기
        }
    }
    public class HitState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.Animator.SetTrigger("Hit");
            owner.CurHp = owner.Hp;
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);
            float distance = Vector3.Distance(owner.transform.position, owner.Target.transform.position);
            if (distance > 50f)
            {
                owner.Target = null;
                ChangeState(owner, Zombie.States.Idle);
            }
            else
            {
                ChangeState(owner, Zombie.States.Trace);
            }
        }
    }
    public class DieState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.Animator.SetTrigger("Die");
            owner.transform.SetParent(owner.Airplane.transform);
            owner.transform.position = owner.Airplane.transform.position;
            owner.gameObject.SetActive(false);
        }
        public override void Update(Zombie owner)
        {
            
        }
        public override void Exit(Zombie owner)
        {

        }
    }
}
