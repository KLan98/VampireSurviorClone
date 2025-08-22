using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schaufel : Bullet
{
    protected override void TriggerReturnToPool()
    {
        SchaufelBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }
}
