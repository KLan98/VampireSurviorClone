using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    protected override void TriggerReturnToPool()
    {
        ZombiePool.Instance.ReturnToPool(this);
    }
}
