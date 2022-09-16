using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator),typeof(CharacterController))]
public class Ariplane : MonoBehaviour
{
    private GameObject dropObject;
    private Animator animator;
    private CharacterController characterController;
    private GroundChecker groundChecker;

    [SerializeField]
    private Transform point;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private float speed;

    private void Awake()
    {
        dropObject = transform.Find("Drop").gameObject;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        groundChecker = GetComponent<GroundChecker>();
    }

    private void OnEnable()
    {
        Vector3 lookTarget = new Vector3(0,0,0);
        lookTarget.x = targetTransform.position.x - transform.position.x;
        lookTarget.z = targetTransform.position.z - transform.position.z;
        transform.forward = lookTarget;
        StartCoroutine(Drop());
    }

    private void Update()
    {
        characterController.Move(transform.forward * Time.deltaTime * speed);
    }

    IEnumerator Drop()
    {
        yield return new WaitUntil(() => groundChecker.isGround==true);
        animator.SetTrigger("Open");
        Collider[] drop = dropObject.GetComponentsInChildren<Collider>(true);
        for (int i = 0; i < drop.Length; i++)
        {
            yield return new WaitForSeconds(Random.Range(0, 2f));
            drop[i].gameObject.SetActive(true);
            if(!groundChecker.isGround)
            {
                break;
            }
        }
        yield return new WaitForSeconds(5f);
        animator.SetTrigger("Close");
    }
}
