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
