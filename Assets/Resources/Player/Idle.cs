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
        bool leftPressed = playerControl.playerInput.Player.Left.IsPressed();
        bool rightPressed = playerControl.playerInput.Player.Right.IsPressed();
        bool upPressed = playerControl.playerInput.Player.Up.IsPressed();
        bool downPressed = playerControl.playerInput.Player.Down.IsPressed();

        // Check for conflicting inputs (left+right or up+down)
        bool horizontalConflict = leftPressed && rightPressed;
        bool verticalConflict = upPressed && downPressed;

        // Only set isMoving to true if there's no conflict and at least one direction is pressed
        if (!horizontalConflict && !verticalConflict && (leftPressed || rightPressed || upPressed || downPressed))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
