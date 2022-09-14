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
            if(owner.Hp< owner.CurHp)
            {
                owner.ChangeState(Zombie.States.Hit);
            }
            if (owner.Hp <= 0)
            {
                owner.ChangeState(Zombie.States.Die);
            }
        }
    }
    public class Fall : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.transform.parent = null;
            owner.animator.SetBool("Fall", true);
        }
        public override void Exit(Zombie owner)
        {
        }
        public override void Update(Zombie owner)
        {
            if(owner.characterController.isGrounded ==true)//수정 필요 레이캐스트로 체크하도록 변경
            {
                owner.animator.SetBool("Fall", false);
                owner.Hp = Random.Range(10f, owner.MaxHP);
                owner.CurHp = owner.Hp;
                owner.ChangeState(Zombie.States.Idle);
            }
        }
    }

    public class Idle : BaseState
    {
        public override void Enter(Zombie owner)
        {
        }
        public override void Exit(Zombie owner)
        {
        }
        public override void Update(Zombie owner)
        {
        }
    }
    public class Trace : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.animator.SetBool("Walk",true);
        }
        public override void Exit(Zombie owner)
        {
        }
        public override void Update(Zombie owner)
        {
            owner.animator.SetBool("Walk", false);
        }
    }
    public class Attack : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.animator.SetTrigger("Attack");
        }
        public override void Exit(Zombie owner)
        {
        }
        public override void Update(Zombie owner)
        {
            if(Physics.)
            owner.ChangeState(Zombie.States.Trace);
        }
    }
    public class Hit : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.animator.SetTrigger("Hit");
        }
        public override void Exit(Zombie owner)
        {
        }
        public override void Update(Zombie owner)
        {
            if(owner.Target ==null)
            {
                owner.ChangeState(Zombie.States.Idle);
            }
            else
            {
                owner.ChangeState(Zombie.States.Trace);
            }
        }
    }
    public class Die : BaseState
    {
        public override void Enter(Zombie owner)
        {
            owner.animator.SetTrigger("Die");
        }
        public override void Exit(Zombie owner)
        {
        }
        public override void Update(Zombie owner)
        {
        }
    }
}
