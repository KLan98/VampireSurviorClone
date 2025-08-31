using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schaufel : Bullet
{
    public IDefaultBehavior defaultBehavior;

    private void Awake()
    {
        defaultBehavior = new BehaviorDefault(this);
    }

    private void FixedUpdate()
    {
        defaultBehavior.FlyStraight();
    }

    protected override void TriggerReturnToPool()
    {
        SchaufelBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }
}
