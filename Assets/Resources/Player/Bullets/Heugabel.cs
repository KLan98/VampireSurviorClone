using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heugabel : Bullet
{
    private IDefaultBehavior DefaultBehavior;

    private void Start()
    {
        DefaultBehavior = new BehaviorDefault(this);    
    }

    private void FixedUpdate()
    {
        DefaultBehavior.FlyStraight(Vector2.up);
    }

    protected override void TriggerReturnToPool()
    {
        HeugabelBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }
}
