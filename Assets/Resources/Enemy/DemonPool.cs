using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonPool : EnemySpawner<Demon>
{
    [SerializeField] private Demon enemyPrefab;
    public static DemonPool Instance;

    protected override int PoolSize()
    {
        return 100;
    }

    protected override Demon EnemyPrefab()
    {
        return enemyPrefab;
    }

    private void Awake()
    {
        PoolEnqueue();
        Instance = this;
    }
}
