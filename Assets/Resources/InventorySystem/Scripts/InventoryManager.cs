using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// In-game inventory manager
/// </summary>
public class InventoryManager : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private SlotClass[] itemDB;
    public SlotClass[] ItemDB => itemDB;
    
    [SerializeField] private SlotClass itemToAdd;
    public SlotClass ItemToAdd
    {
        get
        {
            return itemToAdd;
        }
    }
    [SerializeField] private SlotClass itemToRemove;

    [Header("Game objects")]
    private GameObject[] slotArray;
    [SerializeField] private GameObject slotGameObject; // slot game object of pause menu 
    [SerializeField] private GameObject weaponSelectionGameObject;

    [Header("Components")]
    [SerializeField] private WeaponSelection weaponSelection;
    [SerializeField] private UIManager UIManager;
    private InventoryLogic inventoryLogic;

    private void Awake()
    {
        // Load components
        LoadUIManager();

        InitUI();

        // init components/ game objects/ fields
        LoadSlotsChildren();
        InitItemDB();
    }

    private void Start()
    {
        inventoryLogic = new InventoryLogic(itemDB);
    }

    /// <summary>
    /// Add item to empty itemDB slot
    /// </summary>
    public void AddItem(SlotClass itemToAdd)
    {
        inventoryLogic.AddItem(itemToAdd);
    }

    private void OnEnable()
    {
        EventManager.OnCallAddItem += AddItem;
        EventManager.OnAssignItemToAdd += AssignItemToAdd;
        //EventManager.OnWeaponSelectionUIActive += LoadWeaponSelection;
        EventManager.OnRefreshPauseMenuUI += ArrangeItemToSlot;
    }

    private void OnDisable()
    {
        EventManager.OnCallAddItem -= AddItem;
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