using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : GameState
{
    public override void Enter(GameStateManager gameStateManager)
    {
        base.Enter(gameStateManager);

        UIManager.Instance.playerHealthBarCanvasUI.SetActive(true);
    }
}
