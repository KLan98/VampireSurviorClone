using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sichel : OrbitBullet
{
    private ICirclingBullet BehaviorCirclingBullet;

    protected override void Awake()
    {
        base.Awake();
        BehaviorCirclingBullet = new BehaviorCirclingBullet(this, WeaponClass, playerControl);
    }

    protected override void TriggerReturnToPool()
    {
        SichelBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }

    private void FixedUpdate()
    {
        BehaviorCirclingBullet.OrbitAroundPlayer();
    }
}
