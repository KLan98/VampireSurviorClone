using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    private bool isMoving;

    public Idle(StateMachine stateMachine, PlayerControl playerControl) : base(stateMachine, playerControl)
    {
        this.stateMachine = stateMachine;
        this.playerControl = playerControl;
    }

    public override void PhysicsUpdate()
    {
        playerControl.rb.velocity = new Vector2(0, 0);
    }

    public override void LogicUpdate()
    {
        if (isMoving)
        {
            playerControl.animator.SetBool(Const.PLAYER_MOVING_PARAMETER, true);
            stateMachine.ChangeState(playerControl.moveState);
        }

        else
        {
            //Debug.Log(Const.PLAYER_MOVING_PARAMETER);
        }
    }

    public override void HandleInput()
    {
        if (playerControl.playerInput.Player.Left.IsPressed())
        {
            isMoving = true;
        }

        else if (playerControl.playerInput.Player.Right.IsPressed())
        {
            isMoving = true;
        }

        else if (playerControl.playerInput.Player.Up.IsPressed())
        {
            isMoving = true;
        }

        else if (playerControl.playerInput.Player.Down.IsPressed())
        {
            isMoving = true;
        }

        else
        {
            isMoving = false;
        }
    }
}
