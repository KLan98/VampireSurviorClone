using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageCalculator
{
    private EnemyStats enemyStats;

    public EnemyDamageCalculator(EnemyStats enemyStats)
    {
        this.enemyStats = enemyStats;
    }

    /// <summary>
    /// Return dealt damage to enemy
    /// <summary>
    public int DamageDealtToEnemy(int amount)
    {
        return amount;
    }
}
