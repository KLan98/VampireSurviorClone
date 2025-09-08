using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorHomingBullet : IHomingBullet
{
    private Bullet bullet;

    public BehaviorHomingBullet(Bullet bullet)
    {
        this.bullet = bullet;
    }

    public void TargetNearestEnemy(GameObject nearestEnemy, PlayerControl playerControl)
    {        
        if (nearestEnemy == null)
        {
            return;
        }

        if (!nearestEnemy.gameObject.CompareTag("Enemy"))
        {
            return;
        }

        Vector2 bulletDirection = (nearestEnemy.transform.position - playerControl.transform.position).normalized;
        bullet.gameObject.transform.up = bulletDirection;

        Debug.Log($"{bullet} targets nearest enemy {nearestEnemy}");
    }
}
