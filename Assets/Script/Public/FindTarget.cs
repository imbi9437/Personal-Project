using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    private GameObject target;
    public GameObject Target { get { return target; } }
    private Vector3 position;
    private LayerMask layerMask;
    private LayerMask obsticalLayer;
    private float rad;
    private float angle;

    private void ViewFind()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rad, layerMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 dirVec = (colliders[i].transform.position - transform.position).normalized;
            if (Vector3.Dot(transform.forward, dirVec) > Mathf.Cos(rad * 0.5f * Mathf.Deg2Rad))
            {
                float distance = Vector3.Distance(transform.position, dirVec);
                if (Physics.Raycast(transform.position, colliders[i].transform.position, distance, obsticalLayer))
                {
                    continue;
                }
                target = colliders[i].gameObject;
            }
        }
    }
    public void SoundFind(Vector3 value)
    {
        position = value;
    }
}
