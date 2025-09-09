using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    private bool isIdling;
    private Vector2 forceDirection;
    private Vector2 inputDirection;
    private PlayerStats playerStats;

    public Move(StateMachine stateMachine, PlayerControl playerControl, PlayerStats playerStats) : base(stateMachine, playerControl)
    {
        this.playerStats = playerStats;
    }

    public override void LogicUpdate()
    {
        if (isIdling)
        {
            playerControl.animator.SetBool(Const.PLAYER_MOVING_PARAMETER, false);
            stateMachine.ChangeState(playerControl.idleState);
        }

        // update the parameter
        else
        {
            playerControl.animator.SetBool(Const.PLAYER_MOVING_PARAMETER, true);
            //Debug.Log(Const.PLAYER_MOVING_PARAMETER);
        }
    }

    public override void HandleInput()
    {
        inputDirection = Vector2.zero;

        if (playerControl.playerInput.Player.Up.IsPressed())
        {
            inputDirection += Vector2.up;
        }

        if (playerControl.playerInput.Player.Down.IsPressed())
        {
            inputDirection += Vector2.down;
        }

        if (playerControl.playerInput.Player.Left.IsPressed())
        {
            inputDirection += Vector2.left;
        }

        if (playerControl.playerInput.Player.Right.IsPressed())
        {
            inputDirection += Vector2.right;
        }

        if (inputDirection == Vector2.zero)
        {
            isIdling = true; // No movement input detected 
        }

        else
        {
            //Debug.Log(inputDirection);
            isIdling = false; // At least one direction key is pressed
        }

        // normalize forceDirection so that movement speed in every directions are the same
        forceDirection = inputDirection.normalized;
    }

    public override void PhysicsUpdate()
    {
        playerControl.rb.velocity = forceDirection * playerStats.MovementSpeed;
        //Debug.Log(playerControl.rb.velocity.magnitude);
    }

    public override void SpriteUpdate()
    {
        if (playerControl.playerSprite == null)
        {
            return;
        }

        if (forceDirection.x < 0)
        {
            playerControl.playerSprite.flipX = true;
        }

        else
        {
            playerControl.playerSprite.flipX = false;
        }
    }
}
