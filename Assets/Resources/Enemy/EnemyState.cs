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
        Debug.Log($"{this.enemyController} enters state {this}");
    }

    public virtual void Exit()
    {
        //Debug.Log($"Enemy exits state = {this}");
    }

    /// <summary>
    /// Change state whenever a bool is set
    /// </summary>
    public virtual void LogicUpdate()
    {

    }

    /// <summary>
    /// Update physics for moving objects, if they have rb component
    /// </summary>
    public virtual void PhysicsUpdate()
    {
        if (this.enemyController.gameObject.GetComponent<Rigidbody2D>() == null)
        {
            return;
        }
    }

    /// <summary>
    /// Update local booleans 
    /// </summary>
    public virtual void BoolUpdate()
    {

    }

    public virtual void SpriteUpdate()
    {

    }
}
