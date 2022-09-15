using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Airplane : MonoBehaviour
{
    public enum dropObject { Idle, Zombie, Item }

    private Animator animator;
    private StateMachine<dropObject, Airplane> stateMachine;

    private int randomValue;
    public int RandomValue { get { return randomValue; } }

    [SerializeField]
    private Transform point;
    public Transform Point { get { return point; } }
    [SerializeField]
    private LayerMask layerMask;
    public LayerMask LayerMask { get { return layerMask; } }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        stateMachine.AddState(dropObject.Idle, new AirplaneState.Idle());
        stateMachine.AddState(dropObject.Idle, new AirplaneState.Zombie());
        stateMachine.AddState(dropObject.Idle, new AirplaneState.Item());
    }
    private void OnEnable()
    {
        stateMachine.ChangeState(dropObject.Idle);
        randomValue = Random.Range(0, System.Enum.GetValues(typeof(Airplane.dropObject)).Length);
    }
    private void Update()
    {
        stateMachine.Update();
    }
    public void ChangeState(dropObject next)
    {
        stateMachine.ChangeState(next);
    }


}
