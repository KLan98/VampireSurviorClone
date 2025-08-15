using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomPool : IEnemyPoolProvider
{
    private MonoBehaviour[] enemyPools;

    private void InitEnemyPools()
    {
        enemyPools = new MonoBehaviour[]
        {
            ZombiePool.Instance,
            SkeletonPool.Instance,
            FiendPool.Instance,
            DemonPool.Instance
        };
    }

    public MonoBehaviour PickRandomPool()
    {
        if (enemyPools == null || enemyPools.Length == 0)
        {
            InitEnemyPools();
        }

        int randomIndex = Random.Range(0, enemyPools.Length);
        return enemyPools[randomIndex];
    }
}
