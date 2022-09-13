using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObject/Item/Expandables")]
public class Expandables : Item
{
    public override void Use()
    {
        Debug.Log("소모품 사용");
    }
}
