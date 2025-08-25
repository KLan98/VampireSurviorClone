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

        //Debug.Log($"{this.bullet} knocks back enemies");
        enemy.transform.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * knockForce, ForceMode2D.Impulse);    
    }
}
