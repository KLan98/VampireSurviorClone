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

    public void FlyStraight()
    {
        bullet.transform.Translate(Vector2.up * bullet.WeaponClass.BulletSpeed * Time.deltaTime);
    }
}
