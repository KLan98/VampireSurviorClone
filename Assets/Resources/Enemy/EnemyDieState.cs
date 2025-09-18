using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(EnemyStateMachine enemyStateMachine, EnemyController enemyController) : base(enemyStateMachine, enemyController)
    {

    }

    public override void Enter()
    {
        Enemy dieEnemy = enemyController.enemy;

        if (dieEnemy != null)
        {
            dieEnemy.TriggerReturnToPool();
            EnemyAliveTracker.Instance.OnEnemyDespawned();
        }
    }

    private void PlayDeathAnimation()
    {

    }
}
