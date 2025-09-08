using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO defines behavior for piercing bullet
public class BehaviorPiercingBullet : IPiercingBullet
{
    private Bullet bullet;

    public BehaviorPiercingBullet(Bullet bullet)
    {
        this.bullet = bullet;
    }

    public void PierceEnemies()
    {
        //Debug.Log($"{this.bullet} pierces through enemies");
    }
}
