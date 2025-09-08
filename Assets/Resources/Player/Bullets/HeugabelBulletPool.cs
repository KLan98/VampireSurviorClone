using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeugabelBulletPool : BulletSpawner<Heugabel>
{
    [SerializeField] private Heugabel bulletPrefab;
    public static HeugabelBulletPool Instance;

    protected override int PoolSize()
    {
        return 100;
    }

    private void Awake()
    {
        PoolEnqueue();

        Instance = this;
    }

    protected override Heugabel BulletPrefab()
    {
        return bulletPrefab;
    }
}
