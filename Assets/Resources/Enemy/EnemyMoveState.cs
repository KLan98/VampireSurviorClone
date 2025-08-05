using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private bool isDead;
    private EnemyStateMachine stateMachine;

    public EnemyMoveState(EnemyStateMachine stateMachine, EnemyController enemyController) : base (stateMachine, enemyController)
    {

    }

    public override void LogicUpdate()
    { 
    }

    public override void HandlePhysics()
    {
        
    }
}
