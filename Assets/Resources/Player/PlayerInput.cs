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
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject chooseWeaponMenu;
    private WeaponSelection weaponSelectionComponent;

    private bool pauseMenuActive;

    private void Awake()
    {
        playerInputAction = new PlayerInputActions();
        playerInputAction.Enable();

        pauseMenuActive = false;

        // load components 
        LoadInitWeaponSelectionComponent();
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
        if (chooseWeaponMenu.gameObject.activeInHierarchy == false)
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
                if (chosenWeapon != null && chosenWeapon.IsSlotOccupied && chosenWeapon.GetComponentInChildren<WeaponImage>())
                {
                    Debug.Log($"Player selected slot {chosenWeapon.name}");

                    int selectionIndex = Array.IndexOf(weaponSelectionComponent.slotArray, chosenWeapon.gameObject);

                    //Debug.Log(selectionIndex);

                    EventManager.AssignItemToAdd(selectionIndex);

                    EventManager.CallAddItem();

                    EventManager.RefreshPauseMenuUI();

                    EventManager.WeaponSelected(true);
                }
            }
        }
    }

    private void HandlePauseMenu(InputAction.CallbackContext context)
    {
        //Debug.Log("Escape pressed");

        // Don't allow switching state when the chooseWeaponMenu is active
        if (chooseWeaponMenu.gameObject.activeInHierarchy == true)
        {
            return;
        }

        if (pauseMenuActive == false)
        {
            GameStateManager.Instance.ChangeState(new GamePauseState());
            pauseMenuActive = !pauseMenuActive;
        }

        else
        {
            GameStateManager.Instance.ChangeState(new CombatState());
            pauseMenuActive = !pauseMenuActive;
        }
    }

    private void LoadInitWeaponSelectionComponent()
    {
        weaponSelectionComponent = chooseWeaponMenu.GetComponent<WeaponSelection>();
    }
}
