using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockedBackState : EnemyState
{
    private bool isDead;
    private bool isMoving;

    public EnemyKnockedBackState(EnemyStateMachine stateMachine, EnemyController enemyControler) : base(stateMachine, enemyControler)
    {
    }

    public override void PhysicsUpdate()
    {
        // reset velocity
        enemyController.rb.velocity = Vector2.zero;  
    }

    public override void LogicUpdate()
    {
        if (isDead)
        {
            enemyController.stateMachine.ChangeState(enemyController.enemyDieState);
        }

        else if (isMoving)
        {
            enemyController.stateMachine.ChangeState(enemyController.enemyMoveState);
        }
    }
}
