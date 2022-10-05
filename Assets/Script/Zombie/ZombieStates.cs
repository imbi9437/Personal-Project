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
            if (owner.Hp <= 0)
            {
                ChangeState(owner, Zombie.States.Die);
            }
            if (owner.CurHp > owner.Hp)
            {
                ChangeState(owner, Zombie.States.Hit);
            }
        }
        public void ChangeState(Zombie owner, Zombie.States state)
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
            if (!owner.Animator.GetBool("Fall") && !owner.ZombieAction.IsDelay)
            {
                ChangeState(owner, Zombie.States.Idle);
                return;
            }
            if (owner.ZombieAction.IsDelay)
            {
                return;
            }
            if (owner.GroundChecker.isGround)
            {
                owner.Animator.SetBool("Fall", false);
                owner.ZombieAudio.clip = owner.zombieSound[0];
                owner.ZombieAudio.Play();
                owner.ZombieAction.TimeDelay(7f);
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
            owner.ZombieAudio.clip = owner.zombieSound[1];
            owner.ZombieAudio.loop = true;
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);



            if (owner.FindTarget.Position != Vector3.zero)
            {
                Vector3 ownerVec = new Vector3(owner.transform.position.x, 0, owner.transform.position.z);
                Vector3 targetVec = new Vector3(owner.FindTarget.Position.x, 0, owner.FindTarget.Position.z);
                float distance = Vector3.Distance(ownerVec, targetVec);
                Vector3 moveVec = (targetVec - ownerVec).normalized;
                if (distance > 1f)
                {
                    owner.transform.forward = moveVec;
                    owner.CharacterController.Move(moveVec * owner.Speed * Time.deltaTime);
                }
            }

            owner.FindTarget.ViewFind();
            if (owner.FindTarget.Target != null)
            {
                ChangeState(owner, Zombie.States.Trace);
            }

        }
        public override void Exit(Zombie owner)
        {
            owner.ZombieAudio.Stop();
        }
    }
    public class TraceState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.Animator.SetBool("Trace", true);
            owner.Animator.SetFloat("Speed", owner.Speed);
            owner.ZombieAudio.clip = owner.zombieSound[2];
            owner.ZombieAudio.loop = true;
            owner.ZombieAudio.Play();
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
            if (distance < 1f)
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
            owner.ZombieAudio.Stop();
        }
    }
    public class AttackState : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.Animator.SetInteger("AttackType", Random.Range(0, 2));
            owner.Animator.SetTrigger("Attack");
            if (owner.Animator.GetFloat("AttackType") == 0)
            {
                owner.ZombieAudio.clip = owner.zombieSound[3];
                owner.ZombieAudio.loop = false;
                owner.ZombieAudio.Play();
                owner.ZombieAction.Attack();
            }
            else
            {
                owner.ZombieAudio.clip = owner.zombieSound[4];
                owner.ZombieAudio.loop = false;
                owner.ZombieAudio.Play();
                owner.ZombieAction.Attack();
            }
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);
            owner.FindTarget.ViewFind();
            if (owner.ZombieAction.IsDelay)
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
            owner.ZombieAudio.clip = owner.zombieSound[5];
            owner.ZombieAudio.loop = false;
            owner.ZombieAudio.Play();
            owner.CurHp = owner.Hp;
            owner.ZombieAction.TimeDelay(3f);
        }
        public override void Update(Zombie owner)
        {
            base.Update(owner);
            if (owner.ZombieAction.IsDelay)
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
            owner.ZombieAudio.clip = owner.zombieSound[6];
            owner.ZombieAudio.loop = false;
            owner.ZombieAudio.Play();
            owner.ZombieAction.TimeDelay(10f);
        }
        public override void Update(Zombie owner)
        {
            if (owner.ZombieAction.IsDelay)
            {
                return;
            }
            Vector3 vec = owner.transform.position + owner.transform.up;
            owner.ItemBox.SetActive(true);
            owner.transform.SetParent(owner.AirplaneDrop.transform);
            owner.transform.position = owner.AirplaneDrop.transform.position;
            owner.gameObject.SetActive(false);
        }
        public override void Exit(Zombie owner)
        {

        }
    }
}
