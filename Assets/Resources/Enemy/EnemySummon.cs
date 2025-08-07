using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Summon enemies dynamically outside of the camera
/// </summary>
public class EnemySummon : MonoBehaviour
{
    public float spawnInterval = 1f;
    public float spawnPositionOffset = 2f;
    private MonoBehaviour[] enemyPools;

    private float timer;

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
        // Get camera and bounds
        Camera cam = Camera.main;
        Vector3 camPos = cam.transform.position;
        Vector2 screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        Vector2 spawnPosition = GetOffscreenPosition(screenBounds, camPos);
        Debug.Log(spawnPosition);

        // Get a random enemy pool and spawn an enemy
        MonoBehaviour randomPool = PoolRandomizer();

        if (randomPool != null)
        {
            // Cast to the appropriate pool type and spawn enemy
            if (randomPool is ZombiePool zombiePool)
            {
                Zombie spawnedZombie = zombiePool.SpawnEnemy(spawnPosition);
            }
            else if (randomPool is SkeletonPool skeletonPool)
            {
                Skeleton spawnedSkeleton = skeletonPool.SpawnEnemy(spawnPosition);
            }
            else if (randomPool is DemonPool demonPool)
            {
                Demon spawnedDemon = demonPool.SpawnEnemy(spawnPosition);
            }
            else if (randomPool is FiendPool fiendPool)
            {
                Fiend spawnedFiend = fiendPool.SpawnEnemy(spawnPosition);
            }
        }
    }

    private Vector2 GetOffscreenPosition(Vector2 bounds, Vector3 camPos)
    {
        float x = 0f, y = 0f;
        int side = Random.Range(0, 4); // 0 = Top, 1 = Bottom, 2 = Left, 3 = Right
        Debug.Log($"Spawn side = {side}");
        switch (side)
        {
            case 0: // Top
                x = Random.Range(camPos.x - bounds.x, camPos.x + bounds.x);
                y = camPos.y + bounds.y + spawnPositionOffset;
                break;
            case 1: // Bottom
                x = Random.Range(camPos.x - bounds.x, camPos.x + bounds.x);
                y = camPos.y - bounds.y - spawnPositionOffset;
                break;
            case 2: // Left
                x = camPos.x - bounds.x - spawnPositionOffset;
                y = Random.Range(camPos.y - bounds.y, camPos.y + bounds.y);
                break;
            case 3: // Right
                x = camPos.x + bounds.x + spawnPositionOffset;
                y = Random.Range(camPos.y - bounds.y, camPos.y + bounds.y);
                break;
        }

        return new Vector2(x, y);
    }

    /// <summary>
    /// Pick a random enemy pool
    /// </summary>
    private MonoBehaviour PoolRandomizer()
    {
        if (enemyPools == null || enemyPools.Length == 0)
        {
            InitEnemyPools();
        }
        
        int randomIndex = Random.Range(0, enemyPools.Length);
        return enemyPools[randomIndex];
    }

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
}
