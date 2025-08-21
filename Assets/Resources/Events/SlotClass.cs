using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This attribute makes the class show up in the Unity Inspector when it is a field inside another MonoBehaviour or ScriptableObject.
[System.Serializable]
public class SlotClass
{
    [SerializeField] private ItemScriptableObject item;

    //public SlotClass(ItemScriptableObject item)
    //{
    //    this.item = item;
    //}

    // Get the assigned item in SlotClass
    public ItemScriptableObject GetItem()
    {
        return item;
    }
}
