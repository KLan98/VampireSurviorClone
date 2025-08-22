using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float bulletTimeout = 8.0f;

    public WeaponClass weaponClass;

    protected void Update()
    {
        transform.Translate(Vector2.up * weaponClass.BulletSpeed * Time.deltaTime);
    }

    public void InitBullet(Vector2 spawnPosition, Vector2 spawnDirection)
    {
        this.gameObject.transform.position = spawnPosition;
        this.gameObject.transform.up = spawnDirection; // y-axis as spawnDirection
    }

    protected void OnEnable()
    {
        Invoke(nameof(TriggerReturnToPool), bulletTimeout);
    }

    protected virtual void TriggerReturnToPool()
    {
        Debug.Log($"{this} returned to pool");
    }
}
