using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbility : BaseAbility
{
    [SerializeField] private AbilityData data;
    public override void Use()
    {
        Debug.Log($"Dano: {data.damage}, Tipo: {data.message}");
    }
}
