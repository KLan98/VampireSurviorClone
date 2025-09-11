using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Damage calcultor for player
/// <summary>
public class DamageCalculator
{
    private PlayerStats playerStats;

    public DamageCalculator(PlayerStats playerStats)
    {
        this.playerStats = playerStats;
    }

    /// <summary>
    /// Return dealt damage to player
    /// <summary>
    public int DamageDealtToPlayer(int amount)
    {
        int damageDealt = amount - amount * (int)playerStats.DamageReductionPercentage;
        return damageDealt;
    }
}
