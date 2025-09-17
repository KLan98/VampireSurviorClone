using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiend : Enemy
{
    public override void TriggerReturnToPool()
    {
        FiendPool.Instance.ReturnToPool(this);
    }
}