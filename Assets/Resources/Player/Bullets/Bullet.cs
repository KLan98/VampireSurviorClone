using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // protected float bulletTimeout = 8.0f;

    [SerializeField] private WeaponClass weaponClass;
    public WeaponClass WeaponClass => weaponClass;
    public SpriteRenderer bulletSprite;

    private void Awake()
    {
        LoadBulletSprite();
    }

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

    private void LoadBulletSprite()
    {
        bulletSprite = gameObject.GetComponent<SpriteRenderer>();
    }
}
