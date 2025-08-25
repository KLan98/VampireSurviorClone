using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    public StateMachine stateMachine;
    public PlayerControl playerControl;

    /// <summary>
    /// DI
    /// </summary>
    /// <param name="stateMachine"></param>
    /// <param name="playerControl"></param>
    public State(StateMachine stateMachine, PlayerControl playerControl)
    {
        this.stateMachine = stateMachine;
        this.playerControl = playerControl;
    }

    public virtual void Enter()
    {
        //Debug.Log($"Enter {this} state");
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void Exit()
    {
        //Debug.Log($"Exit state {this}");
    }

    public virtual void SpriteUpdate()
    {

    }
}
