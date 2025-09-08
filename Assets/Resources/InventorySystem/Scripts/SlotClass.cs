using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This attribute makes the class show up in the Unity Inspector when it is a field inside another MonoBehaviour or ScriptableObject.
[System.Serializable]

/// <summary>
/// Purpose of SlotClass is essentially a container (or reference holder) for an ItemScriptableObject
/// <summary>
public class SlotClass
{
    [SerializeField] private ItemScriptableObject item;

    // Get the assigned item in SlotClass
    public ItemScriptableObject GetItem()
    {
        return item;
    }
}
