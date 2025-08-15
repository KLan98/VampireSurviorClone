using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScriptableObject : ScriptableObject
{
    [SerializeField] private string itemName;
    public string ItemName => itemName;
    [SerializeField] private Sprite itemSprite;
    public Sprite ItemSprite => itemSprite;

    public abstract ItemScriptableObject GetItemScriptableObject();
    public abstract WeaponClass GetWeapon();
}

