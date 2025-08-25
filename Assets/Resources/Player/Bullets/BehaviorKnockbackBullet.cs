using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorKnockbackBullet : IKnockbackBullet
{
    private readonly Bullet bullet;
    private float knockForce = 5f;

    public BehaviorKnockbackBullet(Bullet bullet)
    {
        this.bullet = bullet;
    }

    public void KnockbackEnemy(GameObject enemy)
    {
        if (enemy == null)
        {
            return;
        }

        Rigidbody2D enemyRb = enemy.transform.GetComponent<Rigidbody2D>();

        if (enemyRb == null)
        {
            Debug.LogWarning($"No rb found on {enemy}");
            return;
        }

        enemyRb.velocity = Vector2.zero;

        //Debug.Log($"{this.bullet} knocks back enemies");
        enemyRb.AddForce(bullet.transform.up * knockForce, ForceMode2D.Impulse);
    }
}
