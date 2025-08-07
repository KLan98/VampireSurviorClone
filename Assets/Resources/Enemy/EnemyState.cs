using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected EnemyController enemyController;

    public EnemyState (EnemyStateMachine stateMachine, EnemyController enemyController)
    {
        this.stateMachine = stateMachine;
        this.enemyController = enemyController;
    }

    public virtual void Enter()
    {
        //Debug.Log($"Enemy enters state {this}");
    }

    public virtual void Exit()
    {
        //Debug.Log($"Enemy exits state = {this}");
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void HandleInput()
    {

    }
}
