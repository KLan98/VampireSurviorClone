using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [Header("Components")]
    [SerializeField] private InventoryManager inventoryManager;
    public InventoryManager InventoryManager
    {
        get
        {
            return inventoryManager;
        }
    }

    private GameState currentState;

    private void Awake()
    {
        LoadInventoryManager();
        if (Instance == null) Instance = this;

        ChangeState(new ChooseWeaponState());
    }

    private void Update()
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
        currentState = newState; // Switch to new state
        currentState.Enter(this); // Enter the new state
    }

    private void LoadInventoryManager()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        inventoryManager = parent.GetComponentInChildren<InventoryManager>();
    }

    public GameState GetCurrentGameState()
    {
        return currentState;
    }
}
