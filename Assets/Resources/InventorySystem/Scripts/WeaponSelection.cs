using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Choose weapons from a pool and assign it randomly
/// </summary>
public class WeaponSelection : MonoBehaviour
{
    [SerializeField] public SlotClass[] weaponDB;
    public GameObject[] slotArray;
    [SerializeField] private GameObject slotGameObject;

    [Header("Components")]
    [SerializeField] private PoolOfWeapons poolOfWeaponsComponent;

    private void Awake()
    {
        // init components/ game objects/ fields
        InitWeaponDB();
        AllocateWeaponDB();
        LoadSlotsChildren();

        // data processing
        ArrangeItemToSlot();
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

    private void AllocateWeaponDB()
    {
        // clone the og array 
        SlotClass[] shuffledPool = (SlotClass[])poolOfWeaponsComponent.poolOfWeapons.Clone();

        //for (int i = 0; i < shuffledPool.Length; i++)
        //{
        //    Debug.Log(shuffledPool[i].GetItem().name);
        //}

        // Fisher-Yates shuffle
        // declare decrementing list
        for (int i = shuffledPool.Length - 1; i > 0 ; i--)
        {
            //Debug.Log($"Iteration #{i}");
            // j is the chosen index, which is always decrementing
            int j = Random.Range(0, i + 1);
            //Debug.Log("Randomized j " + j);

            // perform swap between i and j 
            SlotClass temp = shuffledPool[i];
            //Debug.Log($"temp {temp.GetItem().ItemName}");
            shuffledPool[i] = shuffledPool[j];
            //Debug.Log($"shuffledPool[i] {shuffledPool[i].GetItem().ItemName} with i = {i}");
            shuffledPool[j] = temp;
            //Debug.Log($"shuffledPool[j] {shuffledPool[j].GetItem().ItemName} with j = {j}");
        }

        //for (int i = 0; i < shuffledPool.Length; i++)
        //{
        //    Debug.Log($"ShuffledPool at index {i} {shuffledPool[i].GetItem().ItemName}");
        //}

        for (int i = 0; i < weaponDB.Length; i++)
        {
            // randomly assign weaponDB
            weaponDB[i] = shuffledPool[i];
            // Debug.Log($"WeaponDB at index {i} {weaponDB[i].GetItem().ItemName}");
        }
    }

    /// <summary>
    /// Display the weapons from weaponDB to UI
    /// </summary>
    private void ArrangeItemToSlot()
    {
        for (int i = 0; i < weaponDB.Length; i++)
        {
            if (weaponDB[i] != null && weaponDB[i].GetItem() != null && weaponDB[i].GetItem().ItemSprite != null)
            {
                slotArray[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = weaponDB[i].GetItem().ItemSprite;
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

    /// <summary>
    /// Init weapon DB array with 3 elements
    /// </summary>
    private void InitWeaponDB()
    {
        weaponDB = new SlotClass[3];
    }
}
