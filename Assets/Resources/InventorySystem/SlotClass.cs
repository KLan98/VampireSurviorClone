using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
    [SerializeField] private ItemScriptableObject item;

    public SlotClass(ItemScriptableObject item)
    {
        this.item = item;
    }
    public ItemScriptableObject GetItem()
    {
        return item;
    }
}
