using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/// <summary>
/// Handle input
/// </summary>
public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions playerInputAction;
    private InventoryManager inventoryManager;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject chooseWeaponMenu;

    private bool pauseMenuActive;

    private void Awake()
    {
        playerInputAction = new PlayerInputActions();
        playerInputAction.Enable();

        pauseMenuActive = false;

        LoadInventoryManager();
    }

    private void OnEnable()
    {
        playerInputAction.Player.PauseMenu.performed += HandlePauseMenu;
        playerInputAction.Player.LeftClick.performed += HandleLeftClick;

    }

    private void OnDisable()
    {
        playerInputAction.Player.PauseMenu.performed -= HandlePauseMenu;
        playerInputAction.Player.LeftClick.performed -= HandleLeftClick;
    }

    private void HandleLeftClick(InputAction.CallbackContext context)
    {
        if (chooseWeaponMenu.gameObject.activeInHierarchy != true)
        {
            return;
        }

        else
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();

            // perform raycast
            EventSystem.current.RaycastAll(pointerData, results);

            foreach (var result in results)
            {
                Slot chosenWeapon = result.gameObject.GetComponent<Slot>();
                if (chosenWeapon != null /*&& chosenWeapon.IsSlotOccupied*/)
                {
                    Debug.Log($"Player selected slot {chosenWeapon.name}");
                    
                    // TODO: find a way to assign itemToAdd

                    EventManager.CallAddItem();          
                }
            }
        }
    }

    private void HandlePauseMenu(InputAction.CallbackContext context)
    {
        Debug.Log("Escape pressed");
        pauseMenuActive = !pauseMenuActive;
        pauseMenu.SetActive(pauseMenuActive);

        // TODO: add pause game (enemies, player and all timer stopped)
    }

    private void LoadInventoryManager()
    {
        inventoryManager = gameObject.GetComponent<InventoryManager>();
    }
}
