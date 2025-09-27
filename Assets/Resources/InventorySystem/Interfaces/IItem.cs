using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public string ItemName {get; }

    public Sprite ItemSprite {get; }

    public float CoolDownTime {get; }

    public int InitDamage {get; }

    public int Level {get; }

    public int NumberOfProjectiles {get; }

    public float BulletSpeed {get; }

    public float BulletSpeedMultiplier {get; }

    public float ProjectileRadius {get; }

    public bool NewWeaponAdded {get; set;}

    public BulletPattern ProjectilePattern {get; set;}

    public enum BulletPattern
    {
        Straight,
        Orbit,
        Boomerang,
        Aura
    }
}
