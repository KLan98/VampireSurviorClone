using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<SlotClass> OnCallAddItem;
    public static event Action<int> OnAssignItemToAdd;
    public static event Action<bool> OnWeaponSelected;
    public static event Action OnRefreshPauseMenuUI;
    public static event Action OnOrbitWeaponSelected;
    public static event Action OnOneMinuteHasPassed;

    public static void CallAddItem(SlotClass itemToAdd)
    {
        OnCallAddItem?.Invoke(itemToAdd);
    }

    public static void TriggerChooseRewardState()
    {
        OnOneMinuteHasPassed?.Invoke();
    }

    /// <summary>
    /// itemToAdd = itemDB[i]
    /// </summary>
    /// <param name="indexOfWeaponDB"></param>
    public static void AssignItemToAdd(int indexOfWeaponDB)
    {
        OnAssignItemToAdd?.Invoke(indexOfWeaponDB);
    }

    public static void WeaponSelected(bool weaponSelected)
    {
        OnWeaponSelected?.Invoke(weaponSelected);
    }

    public static void RefreshPauseMenuUI()
    {
        OnRefreshPauseMenuUI?.Invoke();
    }

    public static void TriggerSpawnOrbitAttack()
    {
        OnOrbitWeaponSelected?.Invoke();
    }
}
