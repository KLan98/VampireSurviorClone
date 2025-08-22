using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : Bullet
{
    private IHomingBullet BehaviorHomingBullet { get; set; }

    private ShotgunBullet()
    {
        this.BehaviorHomingBullet = new BehaviorHomingBullet(this);
    }

    protected override void TriggerReturnToPool()
    {
        ShotgunBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }

    private void Awake()
    {
        BehaviorHomingBullet.TargetNearestEnemy();   
    }
}
