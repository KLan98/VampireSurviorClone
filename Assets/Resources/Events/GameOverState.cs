using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameState
{
    public override void Enter(GameStateManager gameStateManager)
    {
        base.Enter(gameStateManager);        

        // turn on game over screen
        Debug.Log("Game over screen");
        UIManager.Instance.gameOverScreen.SetActive(true);
    }

    public override void Exit()
    {

    }

    public override void StateBehaviorUpdate()
    {
        base.StateBehaviorUpdate();

        Time.timeScale = 0f;
    }
}
