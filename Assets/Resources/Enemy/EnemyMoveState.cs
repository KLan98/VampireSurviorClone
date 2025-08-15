using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private bool isDead;
    private Vector2 forceDirection;
    private float speed = 2.0f;

    public EnemyMoveState(EnemyStateMachine stateMachine, EnemyController enemyController) : base(stateMachine, enemyController)
    {

    }

    public override void LogicUpdate()
    {
        if (isDead)
        {
            enemyController.stateMachine.ChangeState(enemyController.enemyDieState);
        }
    }

    public override void HandleInput()
    {
        //forceDirection = 
    }

    public override void PhysicsUpdate()
    {
        // Handle the movement of enemy, enemies always move toward player
        this.enemyController.rb.position = Vector2.MoveTowards(
                this.enemyController.rb.position,
                enemyController.playerControl.rb.position,
                speed * Time.deltaTime);
    }
}
