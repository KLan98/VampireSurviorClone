using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public override void TriggerReturnToPool()
    {
        ZombiePool.Instance.ReturnToPool(this);
    }
}
