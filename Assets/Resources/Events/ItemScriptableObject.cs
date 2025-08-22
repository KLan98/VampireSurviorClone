using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScriptableObject : ScriptableObject
{
    // fields
    [SerializeField] private string itemName;
    public string ItemName => itemName;

    [SerializeField] private Sprite itemSprite;
    public Sprite ItemSprite => itemSprite;

    [SerializeField] private float coolDownTime;
    public float CoolDownTime => coolDownTime;

    [SerializeField] private bool isPiercingBullet;
    public bool IsPiercingBullet => isPiercingBullet;

    [SerializeField] private bool isKnockBackBullet;
    public bool IsKnockBackBullet => isKnockBackBullet;
    
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

    [SerializeField] private bool isHomingBullet;
    public bool IsHomingBullet
    {
        get
        {
            return isHomingBullet;
        }
    }

    [SerializeField] private float projectileAngle;
    public float ProjectileAngle
    {
        get
        {
            return projectileAngle;
        }
    }

    //
    //public abstract ItemScriptableObject GetItemScriptableObject();
    //public abstract WeaponClass GetWeapon();
}

