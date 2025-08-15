using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Summon enemies dynamically outside of the camera
/// </summary>
public class EnemySummon : MonoBehaviour
{
    public float spawnInterval = 1f;
    private float timer;

    private IEnemyPoolProvider enemyPoolProvider;
    private IEnemyPositionProvider enemyPositionProvider;
    private ICameraProvider cameraProvider;

    private void Awake()
    {
        enemyPoolProvider = new GetRandomPool();
        enemyPositionProvider = new EnemyOffScreenPosition();
        cameraProvider = new EnemyCameraProvider();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        var cam = cameraProvider.GetMainCamera();
        var bounds = cameraProvider.GetScreenBounds();
        var spawnPos = enemyPositionProvider.GetOffscreenPosition(bounds, cam.transform.position);
        var pool = enemyPoolProvider.PickRandomPool();

        SpawnEnemyFromPool(pool, spawnPos);
    }

    /// <summary>
    /// Spawn enemy from pool at spawnPosition
    /// </summary>
    /// <param name="pool"></param>
    /// <param name="spawnPosition"></param>
    private void SpawnEnemyFromPool(MonoBehaviour pool, Vector2 spawnPosition)
    {
        if (pool is ZombiePool zombiePool)
        {
            Zombie spawnedZombie = zombiePool.SpawnEnemy(spawnPosition);
            Debug.Log($"Spawned {spawnedZombie} at position {spawnPosition}");
        }
        else if (pool is SkeletonPool skeletonPool)
        {
            Skeleton spawnedSkeleton = skeletonPool.SpawnEnemy(spawnPosition);
            Debug.Log($"Spawned {spawnedSkeleton} at position {spawnPosition}");
        }
        else if (pool is DemonPool demonPool)
        {
            Demon spawnedDemon = demonPool.SpawnEnemy(spawnPosition);
            Debug.Log($"Spawned {spawnedDemon} at position {spawnPosition}");
        }
        else if (pool is FiendPool fiendPool)
        {
            Fiend spawnedFiend = fiendPool.SpawnEnemy(spawnPosition);
            Debug.Log($"Spawned {spawnedFiend} at position {spawnPosition}");
        }
    }
}
