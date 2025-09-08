using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public abstract class ItemScriptableObject : ScriptableObject
{
    // fields
    [SerializeField] private string itemName;
    public string ItemName => itemName;

    [SerializeField] private Sprite itemSprite;
    public Sprite ItemSprite => itemSprite;

    [HideIf("ProjectilePattern", BulletPattern.Orbit)]
    [SerializeField] private float coolDownTime;
    public float CoolDownTime => coolDownTime;

    [SerializeField] private int initDamage;
    public int InitDamage => initDamage;

    [SerializeField] private int level;
    public int Level => level;

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

    [ShowIf("ProjectilePattern", BulletPattern.Orbit)]
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

    public BulletPattern ProjectilePattern;

    public enum BulletPattern
    {
        Straight,
        Orbit,
        Boomerang,
        Aura
    }
}


