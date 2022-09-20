using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    private GameObject target;
    public GameObject Target { get { return target; } }
    private Vector3 position;
    public Vector3 Position { get { return position; } }
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private LayerMask obsticalLayer;
    [SerializeField]
    private float rad;
    [SerializeField,Range(0f,360f)]
    private float angle;

    public void ViewFind()
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
        if (target != null && Vector3.Distance(transform.position, target.transform.position) > rad)
        {
            target = null;
        }
    }
    public void SoundFind(Vector3 value)
    {
        position = value;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rad);
    }
}
