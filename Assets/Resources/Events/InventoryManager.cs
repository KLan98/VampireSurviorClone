using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// In-game inventory manager, do not let other class call this component
/// </summary>
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private SlotClass[] itemDB;
    public SlotClass[] ItemDB => itemDB;
    [SerializeField] private SlotClass itemToAdd;
    [SerializeField] private SlotClass itemToRemove;


    [Header("Game objects")]
    private GameObject[] slotArray;
    [SerializeField] private GameObject slotGameObject; // slot game object of pause menu 
    [SerializeField] private GameObject weaponSelectionGameObject;

    [Header("Components")]
    [SerializeField] private WeaponSelection weaponSelection;
    [SerializeField] private UIManager UIManager;

    private void Awake()
    {
        // Load components
        LoadUIManager();
        LoadWeaponSelection();

        InitUI();

        // init components/ game objects/ fields
        LoadSlotsChildren();
        InitItemDB();
    }

    /// <summary>
    /// Add item to empty itemDB slot
    /// </summary>
    private void AddItem()
    {
        //Debug.Log("Call add item");

        if (itemDB == null)
        {
            Debug.LogWarning("itemDB is null");
        }

        for (int i = 0; i < itemDB.Length; i++)
        {
            if (itemDB[i] == null)
            {
                Debug.Log(itemDB[i]);

                itemDB[i] = itemToAdd;
                Debug.Log($"Added item {itemToAdd.GetItem().ItemName} to index {i}");

                return;
            }

            else if (itemDB[i] != null)
            {
                Debug.LogWarning($"ItemDB at index {i} is not null, itemDB[i] = {itemDB[i]}");
            }

            else
            {
                Debug.LogWarning($"Exception, value of itemDB[i] is not defined = {itemDB[i]}");
            }
        }
    }

    private void OnEnable()
    {
        EventManager.OnInitWeaponChose += AddItem;
        EventManager.OnAssignItemToAdd += AssignItemToAdd;
        //EventManager.OnWeaponSelectionUIActive += LoadWeaponSelection;
        EventManager.OnRefreshPauseMenuUI += ArrangeItemToSlot;
    }

    private void OnDisable()
    {
        EventManager.OnInitWeaponChose -= AddItem;
        EventManager.OnAssignItemToAdd -= AssignItemToAdd;
        //EventManager.OnWeaponSelectionUIActive -= LoadWeaponSelection;
        EventManager.OnRefreshPauseMenuUI -= ArrangeItemToSlot;
    }

    private void AssignItemToAdd(int index)
    {
        itemToAdd = weaponSelection.weaponDB[index];
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
                if (slotArray[i] != null)
                {
                    slotArray[i].gameObject.GetComponent<Slot>().IsSlotOccupied = false;
                }
            }
        }
    }

    private void LoadWeaponSelection()
    {
        weaponSelection = GameObject.Find("UI_Components").GetComponentInChildren<WeaponSelection>(true);
    }

    private void LoadUIManager()
    {
        UIManager = this.gameObject.transform.parent.GetComponentInChildren<UIManager>();
    }

    private void InitUI()
    {
        weaponSelectionGameObject = UIManager.weaponSelectionUI;
        slotGameObject = UIManager.pauseMenuUI_slotGameObject;
    }

    private void InitItemDB()
    {
        itemDB = new SlotClass[3];

        for (int i = 0; i < itemDB.Length; i++)
        {
            itemDB[i] = null;
        }
    }
}