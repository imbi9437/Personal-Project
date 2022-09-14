using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T> where T : MonoBehaviour
{
    public abstract void Enter(T owner);
    public abstract void Update(T owner);
    public abstract void Exit(T owner);
}
