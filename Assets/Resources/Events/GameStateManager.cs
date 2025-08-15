using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    private GameState currentState;
    //public GameState CurrentState => currentState;

    void Awake()
    {
        if (Instance == null) Instance = this;

        ChangeState(new ChooseWeaponState());
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.StateBehaviorUpdate();
        }
    }

    public void ChangeState(GameState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;  // Switch to new state
        currentState.Enter();     // Enter the new state
    }
}
