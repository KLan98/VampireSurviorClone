using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner<T> : MonoBehaviour where T : Bullet
{
    private Queue<T> bulletPoolQueue = new Queue<T>();
    protected virtual int PoolSize() => default;
    protected virtual T BulletPrefab() => default;

    protected void PoolEnqueue()
    {
        //Debug.Log($"Pool {this} enqueue");
        for (int i = 0; i < PoolSize(); i++)
        {
            T bulletPrefab = Instantiate(BulletPrefab());
            bulletPoolQueue.Enqueue(bulletPrefab);
            bulletPrefab.gameObject.SetActive(false);
            bulletPrefab.gameObject.transform.SetParent(this.transform);
        }
    }

    /// <summary>
    /// Spawn bullet at spawnPosition and with spawnDirection
    /// </summary>
    /// <param name="spawnPosition"></param>
    /// <returns></returns>
    public T SpawnBullet(Vector2 spawnPosition)
    {
        if (bulletPoolQueue.Count == 0)
        {
            PoolEnqueue();
        }

        T spawnedBullet = bulletPoolQueue.Dequeue();
        spawnedBullet.gameObject.SetActive(true);
        spawnedBullet.InitBullet(spawnPosition);
        return spawnedBullet;
    }

    public void ReturnToPool(T bullet)
    {
        bulletPoolQueue.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}
