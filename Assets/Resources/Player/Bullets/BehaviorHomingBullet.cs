using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorHomingBullet : IHomingBullet
{
    private readonly Bullet bullet;

    public BehaviorHomingBullet(Bullet bullet)
    {
        this.bullet = bullet;
    }

    public void TargetNearestEnemy(GameObject nearestEnemy, PlayerControl playerControl)
    {
        Debug.Log($"{bullet} targets nearest enemy {nearestEnemy}");
        if (nearestEnemy == null)
        {
            return;
        }

        Vector2 bulletDirection = (nearestEnemy.transform.position - playerControl.transform.position).normalized;
        bullet.gameObject.transform.up = bulletDirection;
    }
}
