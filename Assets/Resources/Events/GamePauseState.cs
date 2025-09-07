using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : GameState
{
    public override void Enter(GameStateManager gameStateManager)
    {
        base.Enter(gameStateManager);

        UIManager.Instance.pauseMenuUI.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        // exit pause
        Time.timeScale = 1f;
        UIManager.Instance.pauseMenuUI.SetActive(false);

        // Unsubscribe to prevent memory leaks or multiple triggers
    }

    public override void StateBehaviorUpdate()
    {
        // pause game
        Time.timeScale = 0f;
    }
}
