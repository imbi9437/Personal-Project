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
            if(owner.characterController.isGrounded ==true)//���� �ʿ� ����ĳ��Ʈ�� üũ�ϵ��� ����
            {
                owner.animator.SetBool("Fall", false);
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
        }
        public override void Exit(Zombie owner)
        {
        }
        public override void Update(Zombie owner)
        {
        }
    }
    public class Attack : BaseState
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
    public class Hit : BaseState
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
    public class Die : BaseState
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
}
