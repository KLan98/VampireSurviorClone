using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Item/Weapon")]
public class WeaponClass : ItemScriptableObject
{
    public override ItemScriptableObject GetItemScriptableObject()
    {
        return this;
    }

    public override WeaponClass GetWeapon()
    {
        return this;
    }
}