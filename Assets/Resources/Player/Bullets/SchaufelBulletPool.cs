using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchaufelBulletPool : BulletSpawner<Schaufel>
{
    [SerializeField] private Schaufel bulletPrefab;
    public static SchaufelBulletPool Instance;

    protected override int PoolSize()
    {
        return 100;
    }

    protected override Schaufel BulletPrefab()
    {
        return bulletPrefab;
    }

    private void Awake()
    {
        PoolEnqueue();
        Instance = this;
    }
}
