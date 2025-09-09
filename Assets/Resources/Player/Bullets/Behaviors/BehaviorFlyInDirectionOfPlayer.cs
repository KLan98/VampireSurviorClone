using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorFlyInDirectionOfPlayer : IFlyInDirectionOfPlayer
{
    private PlayerControl playerControl;
    private Bullet bullet;

    public BehaviorFlyInDirectionOfPlayer(Bullet bullet, PlayerControl playerControl)
    {
        this.bullet = bullet;
        this.playerControl = playerControl;
    }

    public Vector2 GetPlayerDirection()
    {
        if (playerControl.playerSprite.flipX == true)
        {
            return Vector2.left;
        }

        return Vector2.right;
    }

    public Vector2 GetBulletDirection()
    {
        if (GetPlayerDirection() == Vector2.left)
        {
            return Vector2.down;
        }

        else
        {
            return Vector2.up;
        }
    }

    public void FlipBulletSprite(Vector2 playerDirection)
    {
        if (playerDirection == Vector2.left)
        {
            bullet.bulletSprite.flipY= true;
        }

        else
        {
            bullet.bulletSprite.flipY = false;
        }
    }
}
