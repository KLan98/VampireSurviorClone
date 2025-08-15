using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void InitBullet(Vector2 spawnPosition, Vector2 spawnDirection)
    {
        this.gameObject.transform.position = spawnPosition;
        this.gameObject.transform.up = spawnDirection; // y-axis as spawnDirection
    }

    protected virtual void ReturnToPool()
    {

    }

    protected virtual int CooldownTime() => default;

    protected virtual bool IsPiercing() => default;

    // TODO this is for future implementation
    //protected int Damage() => default;

    //protected int Level() => default;

    //protected int NumberOfProjectiles() => default;
}
