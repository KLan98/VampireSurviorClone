using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorDefault : IDefaultBehavior
{
    private Bullet bullet;

    public BehaviorDefault(Bullet bullet)
    {
        this.bullet = bullet;
    }

    public void FlyStraight(Vector2 direction)
    {
        bullet.transform.Translate(direction * bullet.WeaponClass.BulletSpeed * Time.deltaTime);
    }
}
