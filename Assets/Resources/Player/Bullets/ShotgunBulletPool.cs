using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBulletPool : BulletSpawner<ShotgunBullet>
{
    [SerializeField] private ShotgunBullet bulletPrefab;
    public static ShotgunBulletPool Instance;

    protected override int PoolSize()
    {
        return 100;
    }

    private void Awake()
    {
        PoolEnqueue();

        Instance = this;
    }

    protected override ShotgunBullet BulletPrefab()
    {
        return bulletPrefab;
    }
}
