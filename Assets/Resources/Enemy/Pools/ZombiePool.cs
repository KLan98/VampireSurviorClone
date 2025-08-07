using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePool : EnemySpawner<Zombie>
{
    [SerializeField] private Zombie zombiePrefab;
    public static ZombiePool Instance;

    protected override int PoolSize()
    {
        return 100;
    }

    protected override Zombie EnemyPrefab()
    {
        return zombiePrefab;
    }

    private void LoadZombiePrefab()
    {
        zombiePrefab = GameObject.Find("Enemies").GetComponentInChildren<Zombie>(true);
    }

    private void Awake()
    {
        LoadZombiePrefab();
        PoolEnqueue();
        Instance = this;
    }
}
