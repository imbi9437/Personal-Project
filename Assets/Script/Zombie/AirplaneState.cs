using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class AirplaneState : MonoBehaviour
{
    public class BaseState : State<Airplane>
    {
        public override void Enter(Airplane owner)
        {
        }
        public override void Exit(Airplane owner)
        {
        }
        public override void Update(Airplane owner)
        {
        }
    }
    public class Idle : BaseState
    {
        public override void Enter(Airplane owner)
        {
            
        }
        public override void Exit(Airplane owner)
        {
        }
        public override void Update(Airplane owner)
        {
            if (Physics.Raycast(owner.Point.position, Vector3.down, Mathf.Infinity, owner.LayerMask))
            {
                Airplane.dropObject curState;
                curState = (Airplane.dropObject)owner.RandomValue;
                owner.ChangeState(curState);
            }
        }
    }

    public class Zombie : BaseState
    {
        public override void Enter(Airplane owner)
        {
            
        }
        public override void Exit(Airplane owner)
        {
        }
        public override void Update(Airplane owner)
        {
            if(!Physics.Raycast(owner.Point.position,Vector3.down,Mathf.Infinity,owner.LayerMask))
            {
                owner.gameObject.SetActive(false);
            }
        }
    }
    public class Item : BaseState
    {
        public override void Enter(Airplane owner)
        {
        }
        public override void Exit(Airplane owner)
        {
        }
        public override void Update(Airplane owner)
        {
            if (!Physics.Raycast(owner.Point.position, Vector3.down, Mathf.Infinity, owner.LayerMask))
            {
                owner.gameObject.SetActive(false);
            }
        }
    }
}
