using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(EnemyStateMachine enemyStateMachine, EnemyController enemyController) : base(enemyStateMachine, enemyController)
    {

    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {
        // destroy this gameobject and return it to enemy pool 
    }

    private void PlayDeathAnimation()
    {

    }
}
