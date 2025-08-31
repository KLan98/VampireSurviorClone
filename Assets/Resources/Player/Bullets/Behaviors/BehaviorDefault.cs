using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorDefault : IDefaultBehavior
{
    private readonly Bullet bullet;

    public BehaviorDefault(Bullet bullet)
    {
        this.bullet = bullet;
    }

    public void FlyStraight()
    {
        bullet.transform.Translate(Vector2.up * bullet.weaponClass.BulletSpeed * Time.deltaTime);
    }
}
