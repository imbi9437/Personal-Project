using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    private float distance = 0.1f;
    [SerializeField]
    private Transform point;
    public Transform Point { get { return point; } }

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
