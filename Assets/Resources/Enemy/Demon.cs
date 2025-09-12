using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    public override void TriggerReturnToPool()
    {
        DemonPool.Instance.ReturnToPool(this);
    }
}
