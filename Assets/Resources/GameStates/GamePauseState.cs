using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : GameState
{
    public override void Enter()
    {
        base.Enter();

        UIManager.Instance.pauseMenuUI.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.Instance.pauseMenuUI.SetActive(false);

        // Unsubscribe to prevent memory leaks or multiple triggers
    }

    public override void StateBehaviorUpdate()
    {
        // Optional: extra logic while selecting
        //EventManager.PauseGame();
    }
}
