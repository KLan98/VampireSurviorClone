using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior of shotgun bullet
/// </summary>
public class ShotgunBullet : BulletWithTimeout
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private GameObject nearestEnemy;

    private IHomingBullet BehaviorHomingBullet;
    private IKnockbackBullet BehaviorKnockbackBullet;
    private IDefaultBehavior DefaultBehavior;

    protected override void TriggerReturnToPool()
    {
        ShotgunBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }

    private void Start()
    {
        BehaviorKnockbackBullet = new BehaviorKnockbackBullet(this);
        BehaviorHomingBullet = new BehaviorHomingBullet(this);
        DefaultBehavior = new BehaviorDefault(this);
        BehaviorHomingBullet.TargetNearestEnemy(playerControl.playerAttackRange.nearestEnemy, playerControl);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

        if (enemyController != null)
        {
            // Debug.Log("ShotgunBullet found enemy controller");
            enemyController.stateMachine.ChangeState(enemyController.enemyKnockedBackState);
            BehaviorKnockbackBullet.KnockbackEnemy(collision.gameObject);
            TriggerReturnToPool();
        }

        else
        {
            Debug.Log("ShotgunBullet could not find Enemy controller");
            return;
        }
    }

    private void FixedUpdate()
    {
        DefaultBehavior.FlyStraight(Vector2.up);
    }
}
