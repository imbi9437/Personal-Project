using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGenerator : MonoBehaviour
{
    [SerializeField]
    private float soundRange;
    [SerializeField]
    private float remainSound;
    [SerializeField]
    private LayerMask remainLayer;

    public void SoundGen()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, soundRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 dirVec = (colliders[i].transform.position - transform.position).normalized;
            float distance = Vector3.Distance(colliders[i].transform.position, transform.position);
            RaycastHit[] hit = Physics.RaycastAll(transform.position, dirVec, distance, remainLayer);
            float finalsound = soundRange - (remainSound * hit.Length);
            if (finalsound > 0)
            {
                colliders[i].GetComponent<FindTarget>()?.SoundFind(transform.position);
            }
        }
    }

}
