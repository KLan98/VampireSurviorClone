using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private bool isDead;
    private bool isKnockedBack;
    private Vector2 forceDirection;
    private float moveSpeed = 2.0f;

    public EnemyMoveState(EnemyStateMachine stateMachine, EnemyController enemyController) : base(stateMachine, enemyController)
    {

    }

    public override void LogicUpdate()
    {
        if (isDead)
        {
            enemyController.stateMachine.ChangeState(enemyController.enemyDieState);
        }

        else if (isKnockedBack)
        {
            enemyController.stateMachine.ChangeState(enemyController.enemyKnockedBackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Vector2 enemyPosition = enemyController.rb.position;
        Vector2 playerPosition = enemyController.playerControl.rb.position;

        forceDirection = (playerPosition - enemyPosition).normalized;

        enemyController.rb.velocity = forceDirection * moveSpeed;

        //Debug.Log($"{enemyController.gameObject} has force direction of {forceDirection}");
    }

    public override void BoolUpdate()
    {

    }

    public override void SpriteUpdate()
    {
        Vector2 enemyPosition = enemyController.transform.position;

        Vector2 playerPosition = enemyController.playerControl.transform.position;

        SpriteRenderer enemySprite = enemyController.GetComponent<SpriteRenderer>();

        if (playerPosition.x < enemyPosition.x)
        {
            // Player is on the left
            enemySprite.flipX = true;
        }
        else
        {
            // Player is on the right
            enemySprite.flipX = false;
        }
    }
}
