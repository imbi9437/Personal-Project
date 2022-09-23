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
            if (owner.CurHp > owner.Hp)
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
            if(!owner.Animator.GetBool("Fall")&&!owner.ZombieAction.IsDelay)
            {
                ChangeState(owner, Zombie.States.Idle);
                return;
            }
            if(owner.GroundChecker.isGround)
            {
                owner.Animator.SetBool("Fall", false);
                owner.ZombieAction.TimeDelay(7f);
            }
            if(owner.ZombieAction.IsDelay)
            {
                return;
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
            owner.Animator.SetBool("Trace", false);
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);

            
            if(owner.FindTarget.Position != Vector3.zero)
            {
                Vector3 moveVec = (owner.transform.position - owner.FindTarget.Position).normalized;
                if(owner.transform.position == owner.FindTarget.Position)
                {
                    owner.FindTarget.Position = Vector3.zero;
                }
                else
                {
                    owner.CharacterController.Move(moveVec*owner.Speed*Time.deltaTime);
                }
            }
            
            owner.FindTarget.ViewFind();
            if(owner.FindTarget.Target !=null)
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
            owner.FindTarget.ViewFind();
            if (owner.FindTarget.Target == null)
            {
                ChangeState(owner, Zombie.States.Idle);
                return;
            }
            float distance = Vector3.Distance(owner.transform.position, owner.FindTarget.Target.transform.position);
            if(distance <1f)
            {
                ChangeState(owner, Zombie.States.Attack);
                return;
            }
            Vector3 moveVec = (owner.FindTarget.Target.transform.position - owner.transform.position).normalized;
            owner.CharacterController.Move(moveVec * owner.Speed * Time.deltaTime);
            owner.transform.forward = moveVec;
        }
        public override void Exit(Zombie owner)
        {

        }
    }
    public class AttackState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.Animator.SetInteger("AttackType", Random.Range(0, 2));
            owner.Animator.SetTrigger("Attack");
            owner.ZombieAction.Attack();
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);
            owner.FindTarget.ViewFind();
            if(owner.ZombieAction.IsDelay)
            {
                return;
            }
            if (owner.FindTarget.Target == null)
            {
                ChangeState(owner, Zombie.States.Idle);
            }
            else
            {
                ChangeState(owner, Zombie.States.Trace);
            }
        }
        public override void Exit(Zombie owner)
        {

        }
    }
    public class HitState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.Animator.SetBool("Trace", false);
            owner.Animator.SetTrigger("Hit");
            owner.CurHp = owner.Hp;
            owner.ZombieAction.TimeDelay(2f);
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);
            if(owner.ZombieAction.IsDelay)
            {
                return;
            }
            if (owner.FindTarget.Target == null)
            {
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
            owner.ZombieAction.TimeDelay(10f);
        }
        public override void Update(Zombie owner)
        {
            if(owner.ZombieAction.IsDelay)
            {
                return;
            }
            owner.transform.SetParent(owner.AirplaneDrop.transform);
            owner.transform.position = owner.AirplaneDrop.transform.position;
            owner.gameObject.SetActive(false);
        }
        public override void Exit(Zombie owner)
        {

        }
    }
}
