using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlyInDirectionOfPlayer
{
    public Vector2 GetPlayerDirection();

    public Vector2 GetBulletDirection();

    public void FlipBulletSprite(Vector2 playerDirection);
}
