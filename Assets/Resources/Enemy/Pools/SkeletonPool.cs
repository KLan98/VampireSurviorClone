using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonPool : EnemySpawner<Skeleton>
{
    [SerializeField] private Skeleton enemyPrefab;
    public static SkeletonPool Instance;

    protected override int PoolSize()
    {
        return 100;
    }

    protected override Skeleton EnemyPrefab()
    {
        return enemyPrefab;
    }

    private void LoadEnemyPrefab()
    {
        enemyPrefab = GameObject.Find("Enemies").GetComponentInChildren<Skeleton>(true);
    }

    private void Awake()
    {
        LoadEnemyPrefab();
        PoolEnqueue();
        Instance = this;
    }
}
