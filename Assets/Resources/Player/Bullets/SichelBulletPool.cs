using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SichelBulletPool : BulletSpawner<Sichel>
{
    [SerializeField] private Sichel bulletPrefab;
    public static SichelBulletPool Instance;

    protected override int PoolSize()
    {
        return 100;
    }

    protected override Sichel BulletPrefab()
    {
        return bulletPrefab;
    }

    private void Awake()
    {
        LoadBulletPrefab();
        PoolEnqueue();
        Instance = this;
    }

    private void LoadBulletPrefab()
    {
        bulletPrefab = GameObject.Find("Bullets").GetComponentInChildren<Sichel>(true);
    }
}
