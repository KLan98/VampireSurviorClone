using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum EnemyType
{
    Zombie,
    Skeleton,
    Demon,
    Fiend
}

[Serializable]
public class Wave
{
    [Tooltip("Minimum total alive enemies before switching to periodic spawn pattern.")]
    [SerializeField] private int minimumAliveThreshold;
    public int MinimumAliveThreshold 
    {
        get
        {
            return minimumAliveThreshold;
        }
    }

    [Tooltip("Seconds between spawns during this wave.")]
    [SerializeField] private float spawnIntervalSeconds = 1f;
    public float SpawnIntervalSeconds
    {
        get
        {
            return spawnIntervalSeconds;
        }
    }

    [Tooltip("Enemy types that participate in this wave.")]
    public List<EnemyType> enemyTypes = new List<EnemyType>();
}


