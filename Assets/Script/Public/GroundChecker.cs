using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private CharacterController characterController;
    private float distance = 0.1f;

    [SerializeField]
    LayerMask layerMask;
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
    }

}
