using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Entity/Player")]
public class PlayerStats : EntityWithStats
{
    [SerializeField] private float damageReductionPercentage;
    public float DamageReductionPercentage
    {
        get
        {
            return damageReductionPercentage;
        }
    }
}