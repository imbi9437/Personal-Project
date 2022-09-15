using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private CharacterController characterController;
    private float moveY=0;

    [SerializeField]
    LayerMask layerMask;
    [SerializeField,Range(0f,1f)]
    private float distance = 1f;
    [SerializeField]
    private Transform point;

    public bool isGround { get; private set; }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGround = Physics.Raycast(point.position, Vector3.down, distance, layerMask);
        AddGravity();
    }

    public void AddGravity()
    {
        if(!isGround)
        {
            moveY += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            moveY = 0;
        }

        characterController.Move(Vector3.up * moveY*Time.deltaTime);
    }

}
