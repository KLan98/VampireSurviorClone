using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Choose reward game state
/// <summary>
public class ChooseRewardState : GameState
{
    public override void Enter(GameStateManager gameStateManager)
    {
        base.Enter(gameStateManager);
        UIManager.Instance.chooseReward.SetActive(true);
    }

    public override void StateBehaviorUpdate()
    {
        // Optional: extra logic while selecting
        Time.timeScale = 0f;
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.Instance.chooseReward.SetActive(false);
    }
}
