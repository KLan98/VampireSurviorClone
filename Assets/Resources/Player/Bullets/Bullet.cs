using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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

    protected virtual void TriggerReturnToPool()
    {
        Debug.Log($"{this} returned to pool");
    }

    private void LoadBulletSprite()
    {
        bulletSprite = gameObject.GetComponent<SpriteRenderer>();
    }
}
