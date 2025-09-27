using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle logic of inventory 
/// </summary>
public class InventoryLogic
{
    private ISlotClass[] itemDB;

    public InventoryLogic(ISlotClass[] itemDB)
    {
        this.itemDB = itemDB;
    }

    public void AddItem(ISlotClass itemToAdd)
    {
        //Debug.Log("Call add item");

        if (itemDB == null)
        {
            throw new InvalidOperationException("Item database is null.");
        }

        if (itemToAdd == null)
        {
            throw new ArgumentNullException(nameof(itemToAdd), "Item to add cannot be null.");
        }

        for (int i = 0; i < itemDB.Length; i++)
        {
            if (itemDB[i] == null)
            {
                itemDB[i] = itemToAdd;
                itemDB[i].GetItem().NewWeaponAdded = true;
                // Debug.Log($"Added item {itemToAdd.GetItem().ItemName} to index {i}");
                // Debug.Log($"{itemDB[i].GetItem().ItemName} is a new item = {itemDB[i].GetItem().NewWeaponAdded}");

                return;
            }
        }

        throw new InvalidOperationException("No empty slot available in item database.");
    }
}
