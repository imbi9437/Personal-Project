using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="ScriptableObject/Item/Armor")]
public class Armor : ItemData
{
    public enum Parts { hand, arm, topBody, bottomBody, shoe, head };
    public Parts itemType;
    [SerializeField]
    private float def;
    public float Def { get { return def; } }

    public override void Use(Player player)
    {
        Debug.Log("방어구 사용");
    }
}
