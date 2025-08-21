using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public WeaponClass weaponClass;

    protected void Update()
    {
        transform.Translate(Vector2.up * weaponClass.BulletSpeed * Time.deltaTime);
    }

    protected void Awake()
    {
        //LoadRigidbody();
    }

    public void InitBullet(Vector2 spawnPosition, Vector2 spawnDirection)
    {
        this.gameObject.transform.position = spawnPosition;
        this.gameObject.transform.up = spawnDirection; // y-axis as spawnDirection
    }

    protected virtual void ReturnToPool()
    {

    }

    // return the bulelt to pool if it is not piercing bullet and collide an enemy collider2d
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    //private void LoadRigidbody()
    //{
    //    rb = gameObject.GetComponent<Rigidbody2D>();
    //}
}
