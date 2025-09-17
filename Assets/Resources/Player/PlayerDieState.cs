using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : State
{
    public PlayerDieState(StateMachine stateMachine, PlayerControl playerControl) : base(stateMachine, playerControl)
    {

    }

    public override void Enter()
    {
        // play death animation, shader
        Debug.Log("play death animation");
    }

    public override void Exit()
    {
        // trigger death screen
        
        // trigger game over state
        GameStateManager.Instance.ChangeState(new GameOverState());
    }
}
