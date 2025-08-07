using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script should no be attached to any game object
/// </summary>
/// <typeparam name="T"></typeparam>
public class EnemySpawner<T> : MonoBehaviour where T : Enemy
{
    protected virtual int PoolSize() => default;
    protected virtual T EnemyPrefab() => default;
    public Queue<T> enemyQueue = new Queue<T>();

    // return the spawned game object to the pool
    public void ReturnToPool(T enemy)
    {
        enemyQueue.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public T SpawnEnemy(Vector2 spawnPosition)
    {
        // Enqueue the pool whenever the queue is empty
        if (enemyQueue.Count == 0)
        {
            PoolEnqueue();
        }

        T spawnedEnemy = enemyQueue.Dequeue();
        spawnedEnemy.gameObject.SetActive(true);
        spawnedEnemy.InitPosition(spawnPosition);
        return spawnedEnemy;
    }

    protected void PoolEnqueue()
    {
        for (int i = 0; i < PoolSize(); i++)
        {
            T enemyPrefab = Instantiate(EnemyPrefab());
            enemyQueue.Enqueue(enemyPrefab);
            enemyPrefab.transform.SetParent(this.transform);
            enemyPrefab.gameObject.SetActive(false);
        }
    }
}
