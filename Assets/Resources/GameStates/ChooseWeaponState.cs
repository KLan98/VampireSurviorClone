using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeaponState : GameState
{
    public override void Enter()
    {
        base.Enter();

        UIManager.Instance.weaponSelectionUI.SetActive(true);

        EventManager.WeaponSelectionUIActive();

        // Subscribe to event
        EventManager.OnWeaponSelected += HandleWeaponSelected;
    }

    public override void Exit()
    {
        base.Exit();
        Time.timeScale = 1f;

        UIManager.Instance.weaponSelectionUI.SetActive(false);

        // Unsubscribe to prevent memory leaks or multiple triggers
        EventManager.OnWeaponSelected -= HandleWeaponSelected;
    }

    public override void StateBehaviorUpdate()
    {
        // Optional: extra logic while selecting
        Time.timeScale = 0f;
    }

    private void HandleWeaponSelected(bool weaponSelected)
    {
        if (weaponSelected)
        {
            // Change to the next state after weapon selection
            GameStateManager.Instance.ChangeState(new CombatState());
        }
    }
}
