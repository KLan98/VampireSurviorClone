using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior of orbit bullet: main purpose is to provide the neccessary components for the behavior of orbiting
/// </summary>
public class OrbitBullet : Bullet
{
    protected PlayerControl playerControl;

    protected void LoadPlayerControl()
    {
        playerControl = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
    }

    protected virtual void Awake()
    {
        LoadPlayerControl();
    }
}
