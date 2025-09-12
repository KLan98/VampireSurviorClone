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
        Debug.Log("Enemy died");
    }

    private void PlayDeathAnimation()
    {

    }
}
