using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObject/Item/Used")]
public class Used : ItemData
{
    public enum USEDTYPE { Food, Injection, Etc }
    public USEDTYPE usedType;
    public float heal;
    public float damage;
    public override void Use(Player player)
    {
        switch(usedType)
        {
            case USEDTYPE.Food:
                {
                    player.Hp += heal;
                }
                break;
            case USEDTYPE.Injection:
                {
                    player.Hp += heal;
                }
                break;
        }
    }
}
