using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heugabel : Bullet
{
    private IDefaultBehavior DefaultBehavior;

    private void Awake()
    {
        DefaultBehavior = new BehaviorDefault(this);    
    }

    private void FixedUpdate()
    {
        DefaultBehavior.FlyStraight();
    }

    protected override void TriggerReturnToPool()
    {
        HeugabelBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }
}
