using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiendPool : EnemySpawner<Fiend>
{
    [SerializeField] private Fiend enemyPrefab;
    public static FiendPool Instance;

    protected override int PoolSize()
    {
        return 100;
    }

    protected override Fiend EnemyPrefab()
    {
        return enemyPrefab;
    }

    private void Awake()
    {
        PoolEnqueue();
        Instance = this;
    }
}
