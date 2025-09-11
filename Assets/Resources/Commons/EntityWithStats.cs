using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityWithStats : ScriptableObject
{
    [SerializeField] private float movementSpeed;
    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
    }

    [SerializeField] private int maxHealth;
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }
}
