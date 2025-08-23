using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : Bullet
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private GameObject nearestEnemy;

    private IHomingBullet BehaviorHomingBullet { get; set; }

    public ShotgunBullet()
    {
        BehaviorHomingBullet = new BehaviorHomingBullet(this);
    }

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
        LoadPlayerControl();
        BehaviorHomingBullet.TargetNearestEnemy(playerControl.playerAttackRange.nearestEnemy, playerControl);
    }
}
