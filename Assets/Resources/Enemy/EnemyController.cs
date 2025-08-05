using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyStateMachine stateMachine;
    private EnemyMoveState enemyMoveState;

    private void Awake()
    {
        stateMachine = new EnemyStateMachine();
        enemyMoveState = new EnemyMoveState(stateMachine, this);

        stateMachine.InitState(enemyMoveState);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
