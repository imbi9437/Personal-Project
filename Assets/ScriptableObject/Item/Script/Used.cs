using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObject/Item/Used")]
public class Used : ItemData
{
    public enum usedType { Food, Injection, Etc }
    public usedType itemType;
    public float heal;
    public float damage;
    public override void Use(Player player)
    {
        switch(itemType)
        {
            case usedType.Food:
                {
                    player.Hp += heal;
                }
                break;
            case usedType.Injection:
                {
                    player.Hp += heal;
                }
                break;
        }
    }
}
