using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="ScriptableObject/Item/Armor")]
public class Armor : Item
{
    public enum Parts { hand, arm, topBody, bottomBody, shoe, head };

    [SerializeField]
    private float def;
    public float Def { get { return def; } }
    [SerializeField]
    private Parts part;
    public Parts Part { get { return part; } }
    public override void Use()
    {
        Debug.Log("방어구 사용");
    }
}
