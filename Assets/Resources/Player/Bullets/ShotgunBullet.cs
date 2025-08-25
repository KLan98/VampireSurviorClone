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

    private void LoadPlayerControl()
    {
        playerControl = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
    }

    protected override void TriggerReturnToPool()
    {
        ShotgunBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }

    private void Awake()
    {
        BehaviorKnockbackBullet = new BehaviorKnockbackBullet(this);
        BehaviorHomingBullet = new BehaviorHomingBullet(this);
        LoadPlayerControl();
        BehaviorHomingBullet.TargetNearestEnemy(playerControl.playerAttackRange.nearestEnemy, playerControl);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            BehaviorKnockbackBullet.KnockbackEnemy(collision.transform.gameObject);
            TriggerReturnToPool();
        }
    }
}
