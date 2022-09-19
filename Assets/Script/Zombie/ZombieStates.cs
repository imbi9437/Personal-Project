using System.Collections;
using System.Collections.Generic;
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
                owner.ZombieAction.ChangeState(Zombie.States.Die);
            }
            if (owner.CurHp < owner.Hp)
            {
                owner.ZombieAction.ChangeState(Zombie.States.Hit);
            }
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

        }
    }
    public class IdleState : BaseState
    {

    }
    public class TraceState : BaseState
    {

    }
    public class AttackState : BaseState
    {

    }
    public class HitState : BaseState
    {

    }
    public class DieState : BaseState
    {

    }
}
