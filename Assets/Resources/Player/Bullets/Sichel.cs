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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyController enemyController = collider.gameObject.GetComponent<EnemyController>();

        if (enemyController != null)
        {
            Debug.Log($"{this} hits {enemyController}");
        }

        else
        {
            return;
        }
    }
}
