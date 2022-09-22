using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Item/Ingredient")]
public class Ingredient : ItemData
{
    public enum ingredientType { ModulePart, Ingredient }
    public ingredientType itemType;

    public override void Use()
    {
        Debug.Log("재료 사용");
    }
}
