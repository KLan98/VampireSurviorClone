using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockedBackState : EnemyState
{
    private bool isDead;
    private bool isMoving;
    private float knockbackTimeout = 0.6f; // the time in which enemy stucks in this state
    private float knockbackTimer = 0f; // count up timer if this value >= knockbackTimeout then leave this state

    public EnemyKnockedBackState(EnemyStateMachine stateMachine, EnemyController enemyControler) : base(stateMachine, enemyControler)
    {
    }

    public override void Enter()
    {
        base.Enter();

        isMoving = false;
        isDead = false;

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
            // After knockback time passes, go back to move
            enemyController.stateMachine.ChangeState(enemyController.enemyMoveState);
        }
    }

    public override void BoolUpdate()
    {
        knockbackTimer += Time.deltaTime;

        if (knockbackTimer >= knockbackTimeout)
        {
            knockbackTimer = 0f;
            isMoving = true;
        }
    }
}
