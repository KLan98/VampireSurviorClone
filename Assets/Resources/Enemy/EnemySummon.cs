using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Summon enemies dynamically outside of the camera, based on MainTimer
/// </summary>
public class EnemySummon : MonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField] private WaveSet waveSet;
    [SerializeField] private int maxAliveCap = 300; // max number of enemies alive spawned

    [Header("Components")]
    [SerializeField] private TimerBar timerBar;

    // fields
    private float periodicSpawnTimer;
    private int maxGameTime = 20; // max game time in minute

    private IEnemyPoolProvider enemyPoolProvider;
    private IEnemyPositionProvider enemyPositionProvider;

    private void Awake()
    {
        enemyPoolProvider = new GetRandomPool();
        enemyPositionProvider = new EnemyOffScreenPosition();
    }

    private void Update()
    {
        Wave currentWave = GetCurrentWave();

        if (currentWave == null)
        {
            return;
        }

        int enemiesAlive;
        if (EnemyAliveTracker.Instance != null)
        {
            enemiesAlive = EnemyAliveTracker.Instance.AliveCount;
        }
        else
        {
            enemiesAlive = 0;
        }

        if (enemiesAlive >= maxAliveCap)
        {
            return;
        }

        if (enemiesAlive < currentWave.MinimumAliveThreshold)
        {
            SpawnUntilThreshold(currentWave, currentWave.MinimumAliveThreshold - enemiesAlive);
            return;
        }

        periodicSpawnTimer += Time.deltaTime;
        if (periodicSpawnTimer >= Mathf.Max(0.05f, currentWave.SpawnIntervalSeconds))
        {
            SpawnOneOfEach(currentWave);
            periodicSpawnTimer = 0f;
        }
    }

    private Wave GetCurrentWave()
    {
        if (waveSet == null || waveSet.Waves == null || waveSet.Waves.Count == 0)
        {
            return null;
        }

        int minuteIndex = Mathf.CeilToInt(timerBar.MainTimer / 60f); // current minute
        // Debug.Log($"Minute index {minuteIndex}");

        int waveIndex = maxGameTime - minuteIndex;

        int waveCounts = waveSet.Waves.Count; // wave counts 

        // if there are less waves than wave index then return the latest wave index
        // wave count = 2 < wave index = 3
        // only spawn wave index = wave count - 1
        if (waveCounts <= waveIndex)
        {
            // Debug.Log("Spawn only the latest wave from now on");
            waveIndex = waveCounts - 1;
        }

        return waveSet.Waves[waveIndex];
    }

    private void SpawnUntilThreshold(Wave wave, int toSpawn)
    {
        for (int i = 0; i < toSpawn; i++)
        {
            EnemyType type;
            if (wave.enemyTypes.Count > 0)
            {
                type = wave.enemyTypes[i % wave.enemyTypes.Count];
            }
            else
            {
                type = EnemyType.Zombie;
            }

            SpawnEnemyOfType(type);
        }
    }

    private void SpawnOneOfEach(Wave wave)
    {
        if (wave.enemyTypes == null || wave.enemyTypes.Count == 0)
        {
            return;
        }

        foreach (var type in wave.enemyTypes)
        {
            SpawnEnemyOfType(type);
        }
    }

    private void SpawnEnemyOfType(EnemyType type)
    {
        Vector2 spawnPos = enemyPositionProvider.GetOffscreenPosition();

        MonoBehaviour pool = GetPoolByType(type);
        if (pool == null)
        {
            return;
        }

        SpawnEnemyFromPool(pool, spawnPos);

        if (EnemyAliveTracker.Instance != null)
        {
            EnemyAliveTracker.Instance.OnEnemySpawned();
        }
    }

    private MonoBehaviour GetPoolByType(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Zombie:
                return ZombiePool.Instance;
            case EnemyType.Skeleton:
                return SkeletonPool.Instance;
            case EnemyType.Demon:
                return DemonPool.Instance;
            case EnemyType.Fiend:
                return FiendPool.Instance;
            default:
                return null;
        }
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
            //Debug.Log($"Spawned {spawnedZombie} at position {spawnPosition}");
        }
        else if (pool is SkeletonPool skeletonPool)
        {
            Skeleton spawnedSkeleton = skeletonPool.SpawnEnemy(spawnPosition);
            //Debug.Log($"Spawned {spawnedSkeleton} at position {spawnPosition}");
        }
        else if (pool is DemonPool demonPool)
        {
            Demon spawnedDemon = demonPool.SpawnEnemy(spawnPosition);
            //Debug.Log($"Spawned {spawnedDemon} at position {spawnPosition}");
        }
        else if (pool is FiendPool fiendPool)
        {
            Fiend spawnedFiend = fiendPool.SpawnEnemy(spawnPosition);
            //Debug.Log($"Spawned {spawnedFiend} at position {spawnPosition}");
        }
    }
}
