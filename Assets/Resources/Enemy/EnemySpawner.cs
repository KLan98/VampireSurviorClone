using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int poolSize = 500;
    [SerializeField] private int enemiesSpawned = 0;
    [SerializeField] private float spawnInterval = 1.0f;

    //private Vector2 GetSpawnPosition()
    //{
    //    return new Vector2(Ran)
    //}
}
