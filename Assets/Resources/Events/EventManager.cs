using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnInitWeaponChose;
    public static event Action<int> OnAssignItemToAdd;
    public static event Action<bool> OnWeaponSelected;
    public static event Action OnRefreshPauseMenuUI;
    public static event Action OnOrbitWeaponSelected;

    public static void CallAddItem()
    {
        OnInitWeaponChose?.Invoke();
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
