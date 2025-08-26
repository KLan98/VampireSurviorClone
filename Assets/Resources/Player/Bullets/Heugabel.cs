using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heugabel : Bullet
{
    protected override void TriggerReturnToPool()
    {
        HeugabelBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }
}
