using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObject/Item/Used")]
public class Usde : ItemData
{
    public enum usedType { Food, Injection, Etc }
    public usedType itemType;
    public float heal;

    public override void Use()
    {
        Debug.Log("�Ҹ�ǰ ���");
    }
}
