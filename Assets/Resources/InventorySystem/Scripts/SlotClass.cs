using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Purpose of SlotClass is essentially a container (or reference holder) for an ItemScriptableObject
/// <summary>
[System.Serializable]
public class SlotClass : ISlotClass
{
    [SerializeField] private ItemScriptableObject item;

    public IItem GetItem()
    {
        return item;
    }
}
