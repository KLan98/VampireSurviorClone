using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorKnockbackBullet : IKnockbackBullet
{
    private readonly Bullet bullet;
    private float knockbackForce = 1.5f;

    public BehaviorKnockbackBullet(Bullet bullet)
    {
        this.bullet = bullet;
    }

    /// <summary>
    /// Knocking back enemy by add a force to its rigidbody
    /// </summary>
    /// <param name="enemy"></param>
    public void KnockbackEnemy(GameObject enemy)
    {
        if (enemy == null)
        {
            return;
        }

        enemy.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * knockbackForce, ForceMode2D.Impulse);
    }
}
