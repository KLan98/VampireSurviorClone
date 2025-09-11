using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Entity/Enemy")]
public class EnemyStats : EntityWithStats
{
    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
    }
}