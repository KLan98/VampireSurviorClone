using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior of circling bullet: revolving around player based on the number of projectiles of Scriptable Object
/// </summary>
public class BehaviorCirclingBullet : ICirclingBullet
{
    private readonly Bullet bullet;
    private readonly WeaponClass weapon;
    private readonly PlayerControl playerControl;

    public BehaviorCirclingBullet(Bullet bullet, WeaponClass weapon, PlayerControl playerControl)
    {
        this.bullet = bullet;
        this.weapon = weapon;
        this.playerControl = playerControl;
    }

    public void OrbitAroundPlayer()
    {
        bullet.transform.RotateAround(playerControl.transform.position, Vector3.forward, 20 * weapon.BulletSpeed * Time.deltaTime);
    }
}
