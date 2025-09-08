using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior of shotgun bullet
/// </summary>
public class ShotgunBullet : Bullet
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private GameObject nearestEnemy;

    private IHomingBullet BehaviorHomingBullet;
    private IKnockbackBullet BehaviorKnockbackBullet;
    private IDefaultBehavior DefaultBehavior;

    private void LoadPlayerControl()
    {
        playerControl = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
    }

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
        LoadPlayerControl();
        BehaviorHomingBullet.TargetNearestEnemy(playerControl.playerAttackRange.nearestEnemy, playerControl);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

        if (enemyController != null)
        {
            enemyController.stateMachine.ChangeState(enemyController.enemyKnockedBackState);
            BehaviorKnockbackBullet.KnockbackEnemy(collision.gameObject);
            TriggerReturnToPool();

            //enemyController.stateMachine.ChangeState(e)
            //Debug.Log($"{this} hits {collision.transform.gameObject}");
        }

        else
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        DefaultBehavior.FlyStraight();
    }
}
