using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private bool isDead;
    private Vector2 forceDirection;
    private EnemyStats enemyStats;

    public EnemyMoveState(EnemyStateMachine stateMachine, EnemyController enemyController, EnemyStats enemyStats) : base(stateMachine, enemyController)
    {
        this.enemyStats = enemyStats;
    }

    public override void LogicUpdate()
    {
        if (isDead)
        {
            enemyController.stateMachine.ChangeState(enemyController.enemyDieState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Vector2 enemyPosition = enemyController.rb.position;
        Vector2 playerPosition = enemyController.playerControl.rb.position;

        forceDirection = (playerPosition - enemyPosition).normalized;

        enemyController.rb.velocity = forceDirection * enemyStats.MovementSpeed;

        //Debug.Log($"{enemyController.gameObject} has force direction of {forceDirection}");
    }

    public override void SpriteUpdate()
    {
        Vector2 enemyPosition = enemyController.transform.position;

        Vector2 playerPosition = enemyController.playerControl.transform.position;

        if (playerPosition.x < enemyPosition.x)
        {
            // Player is on the left
            enemyController.enemySprite.flipX = true;
        }
        else
        {
            // Player is on the right
            enemyController.enemySprite.flipX = false;
        }
    }

    public override void BoolUpdate()
    {
        if (enemyController.damageReceiver.CurrentHealth <= 0)
        {
            isDead = true;
        }

        else
        {
            isDead = false;
        }
    }
}
