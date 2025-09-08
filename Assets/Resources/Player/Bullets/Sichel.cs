using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sichel : Bullet
{
    private ICirclingBullet BehaviorCirclingBullet;
    [SerializeField] private PlayerControl playerControl;

    private void Start()
    {
        BehaviorCirclingBullet = new BehaviorCirclingBullet(this, WeaponClass, playerControl);
    }

    private void FixedUpdate()
    {
        BehaviorCirclingBullet.OrbitAroundPlayer();
    }
}
