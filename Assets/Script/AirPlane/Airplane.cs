using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Animator),typeof(CharacterController),typeof(AudioSource))]
public class Airplane : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private GroundChecker groundChecker;
    private AudioSource audioSource;

    [SerializeField]
    private GameObject zombie;
    [SerializeField]
    private GameObject supplyItem;
    [SerializeField]
    private GameObject dropObject;

    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private float speed;

    private int random;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        groundChecker = GetComponent<GroundChecker>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        random = Random.Range(1, 10);
        Vector3 lookTarget = targetTransform.position - transform.position;
        lookTarget.y = 0;
        transform.forward = lookTarget;
        audioSource.Play();
        if (random == 10)
        {
            GameObject itemBox = Instantiate(supplyItem, dropObject.transform, false);
            itemBox.SetActive(false);
        }
        CheckOut();
        StartCoroutine(Drop());
    }

    private void Update()
    {
        characterController.Move(transform.forward * Time.deltaTime * speed);
    }
    private void OnDisable()
    {
        audioSource.Stop();
    }
    private void CheckOut()
    {
        Collider[] drop = dropObject.GetComponentsInChildren<Collider>(true);
        if(drop.Length<20)
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject zombieObject = Instantiate(zombie, dropObject.transform, false);
                zombieObject.SetActive(false);
            }
        }
    }

    IEnumerator Drop()
    {
        yield return new WaitUntil(() => groundChecker.isGround==true);
        yield return new WaitForSeconds(2f);
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
        animator.SetTrigger("Close");
        yield return new WaitUntil(() => groundChecker.isGround == false);
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}
