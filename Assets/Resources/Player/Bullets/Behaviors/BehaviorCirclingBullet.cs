using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior of circling bullet: revolving around player based on the number of projectiles of Scriptable Object
/// </summary>
public class BehaviorCirclingBullet : ICirclingBullet
{
    private Bullet bullet;
    private WeaponClass weapon;
    private PlayerControl playerControl;

    private float angle;       // Current angle around the player
    private float orbitRadius; // Distance from player

    public BehaviorCirclingBullet(Bullet bullet, WeaponClass weapon, PlayerControl playerControl)
    {
        this.bullet = bullet;
        this.weapon = weapon;
        this.playerControl = playerControl;

        // Get initial offset from player
        Vector3 offset = bullet.transform.position - playerControl.transform.position;
        // Debug.Log($"Init offset = {offset}");
        orbitRadius = offset.magnitude;

        // Calculate starting angle from spawn position
        angle = Mathf.Atan2(offset.y, offset.x);

        // Debug.Log($"init angle = {angle}");
    }

    public void OrbitAroundPlayer()
    {
        // Update angle over time (clockwise or counterclockwise)
        angle -= weapon.BulletSpeedMultiplier * weapon.BulletSpeed * Time.deltaTime;

        // Calculate orbit offset
        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;

        Vector3 orbitPositionOffset = new Vector3(x, y, 0f);

        // Keep position relative to moving player
        bullet.transform.position = playerControl.transform.position + orbitPositionOffset;
    }
}
