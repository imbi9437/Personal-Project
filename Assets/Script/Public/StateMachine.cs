using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine<T1, T2> where T2 : MonoBehaviour
{
    private T2 owner;
    private State<T2> curState;
    private Dictionary<T1, State<T2>> states;

    public StateMachine(T2 owner)
    {
        this.owner = owner;
        curState = null;
        states = new Dictionary<T1, State<T2>>();
    }
    public void Update()
    {
        curState.Update(owner);
    }

    public void AddState(T1 type, State<T2> state)
    {
        states.Add(type, state);
    }
    public void ChangeState(T1 type)
    {
        if (curState != null)
        {
            curState.Exit(owner);
        }
        curState = states[type];
        curState.Enter(owner);
    }
}
