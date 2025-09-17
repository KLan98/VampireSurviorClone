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
    }

    public override void Exit()
    {
        // trigger death screen

        // change state
    }
}
