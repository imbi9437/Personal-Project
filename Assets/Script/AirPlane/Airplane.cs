using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Animator),typeof(CharacterController),typeof(AudioSource))]
public class Airplane : MonoBehaviour
{
    [SerializeField]
    private GameObject zombie;
    [SerializeField]
    private GameObject supplyItem;

    private GameObject dropObject;
    private Animator animator;
    private CharacterController characterController;
    private GroundChecker groundChecker;
    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Vector3 lookTarget = new Vector3(0,0,0);
        lookTarget.x = targetTransform.position.x - transform.position.x;
        lookTarget.z = targetTransform.position.z - transform.position.z;
        transform.forward = lookTarget;
        audioSource.Play();
        CheckOut();
        if (GameManager.instance.drop < 10)
        {
            StartCoroutine(DropZombie());
        }
        else if(GameManager.instance.drop==10)
        {

        }
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
                GameObject zombieObject = Instantiate(zombie);
                zombieObject.transform.SetParent(dropObject.transform, false);
                zombieObject.SetActive(false);
            }
        }
    }

    IEnumerator DropZombie()
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
    IEnumerator DropItem()
    {
        yield return new WaitUntil(() => groundChecker.isGround == true);
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("Open");
        yield return new WaitForSeconds(Random.Range(0,30f));
        
    }
}
