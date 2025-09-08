using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // protected float bulletTimeout = 8.0f;

    [SerializeField] private WeaponClass weaponClass;
    public WeaponClass WeaponClass => weaponClass;

    public void InitBullet(Vector2 spawnPosition)
    {
        this.gameObject.transform.position = spawnPosition;
    }

    // protected virtual void OnEnable()
    // {
    //     Invoke(nameof(TriggerReturnToPool), bulletTimeout);
    // }

    protected virtual void TriggerReturnToPool()
    {
        Debug.Log($"{this} returned to pool");
    }
}
