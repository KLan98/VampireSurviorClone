using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// In-game inventory manager
/// </summary>
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private SlotClass[] itemDB;
    [SerializeField] public SlotClass itemToAdd;
    [SerializeField] private SlotClass itemToRemove;
    private GameObject[] slotArray;
    [SerializeField] private GameObject slotGameObject;

    private void Awake()
    {
        // init components/ game objects/ fields
        LoadSlotsChildren();

        // data processing
        ArrangeItemToSlot();
    }

    /// <summary>
    /// Add item to empty itemDB slot
    /// </summary>
    private void AddItem()
    {
        if (itemDB == null)
        {
            Debug.LogWarning("itemDB is null");
        }

        for (int i = 0; i < itemDB.Length; i++)
        {
            if (itemDB[i].GetItem() != null)
            {
                Debug.Log($"This slot at index {i} is already has an item {itemDB[i].GetItem().ItemName}");
            }

            else
            {
                Debug.Log($"Added item {itemToAdd.GetItem().ItemName} to index {i}");
                itemDB[i] = itemToAdd;
                return;
            }
        }
    }

    private void OnEnable()
    {
        EventManager.OnInitWeaponChose += AddItem;

    }

    private void OnDisable()
    {
        EventManager.OnInitWeaponChose -= AddItem;
    }

    /// <summary>
    /// Populates the <see cref="slot"/> array with the child GameObjects of <see cref="slotsGameObject"/>.
    /// </summary>
    /// <remarks>This method initializes the <see cref="slot"/> array to match the number of child GameObjects
    /// under <see cref="slotsGameObject"/> and assigns each child GameObject to the corresponding index in the
    /// array.</remarks>
    private void LoadSlotsChildren()
    {
        // create new game objects based on the amount of children of slotsGameObject
        slotArray = new GameObject[slotGameObject.transform.childCount];

        // populate slot array
        for (int i = 0; i < slotGameObject.transform.childCount; i++)
        {
            slotArray[i] = slotGameObject.transform.GetChild(i).gameObject;
        }
    }

    /// <summary>
    /// Display the weapons from itemDB to UI
    /// </summary>
    private void ArrangeItemToSlot()
    {
        for (int i = 0; i < itemDB.Length; i++)
        {
            if (itemDB[i] != null && itemDB[i].GetItem() != null && itemDB[i].GetItem().ItemSprite != null)
            {
                slotArray[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = itemDB[i].GetItem().ItemSprite;
                slotArray[i].gameObject.GetComponent<Slot>().IsSlotOccupied = true;
            }
            else
            {
                // Optionally clear the slot if there is no item
                if (slotArray[i] != null)
                {
                    slotArray[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
                    slotArray[i].gameObject.GetComponent<Slot>().IsSlotOccupied = false;
                }
            }
        }
    }
}