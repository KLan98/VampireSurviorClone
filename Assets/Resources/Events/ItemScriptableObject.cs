using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ItemScriptableObject : ScriptableObject, IItem
{
    // fields
    [SerializeField] private string itemName;
    public string ItemName 
    {
        get
        {
            return itemName;
        }
    }

    [SerializeField] private Sprite itemSprite;
    public Sprite ItemSprite
    {
        get
        {
            return itemSprite;
        }
    }

    [HideIf("ProjectilePattern", IItem.BulletPattern.Orbit)]
    [SerializeField] private float coolDownTime;
    public float CoolDownTime
    {
        get
        {
            return coolDownTime;
        }
    }

    [SerializeField] private int initDamage;
    public int InitDamage
    {
        get
        {
            return initDamage;
        }
    }

    [SerializeField] private int level;
    public int Level
    {
        get
        {
            return level;
        }
    }

    [SerializeField] private int numberOfProjectiles;
    public int NumberOfProjectiles
    {
        get
        {
            return numberOfProjectiles;
        }
    }

    [SerializeField] private float bulletSpeed;
    public float BulletSpeed
    {
        get
        {
            return bulletSpeed;
        }
    }

    [SerializeField] private int bulletSpeedMultiplier;
    public float BulletSpeedMultiplier
    {
        get
        {
            return bulletSpeedMultiplier;
        }
    }

    [ShowIf("ProjectilePattern", IItem.BulletPattern.Orbit)]
    [SerializeField] private float projectileRadius;
    public float ProjectileRadius
    {
        get
        {
            return projectileRadius;
        }
    }

    private bool newWeaponAdded; // check if the weapon is newly added to inventory
    public bool NewWeaponAdded
    {
        get
        {
            return newWeaponAdded;
        }

        set
        {
            newWeaponAdded = value;
        }
    }

    [SerializeField] private IItem.BulletPattern projectilePattern;

    public IItem.BulletPattern ProjectilePattern
    {
        get
        {
            return projectilePattern;
        }

        set
        {
            projectilePattern = value;
        }
    }
}


