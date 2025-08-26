using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sichel : Bullet
{
    protected override void TriggerReturnToPool()
    {
        SichelBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }
}
