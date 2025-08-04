using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool isSlotOccupied;

    public bool IsSlotOccupied
    {
        get 
        {
            return isSlotOccupied;
        }

        set
        {
            isSlotOccupied = value;
        }
    }
}
