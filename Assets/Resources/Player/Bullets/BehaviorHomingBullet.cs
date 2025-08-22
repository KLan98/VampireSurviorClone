using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorHomingBullet : IHomingBullet
{
    [SerializeField] private PlayerControl playerControl;

    private readonly GameObject nearestEnemy;

    private readonly Bullet bullet;

    private void Awake()
    {
        LoadPlayerControl();
    }

    public BehaviorHomingBullet(Bullet bullet, GameObject nearestEnemy)
    {
        this.bullet = bullet;
        this.nearestEnemy = nearestEnemy;
    }

    public void TargetNearestEnemy()
    {
        Debug.Log($"{this.bullet} bullet targets nearest enemy");
        if (nearestEnemy == null)
        {
            return;
        }

        Vector2 bulletDirection = (nearestEnemy.transform.position - this.playerControl.transform.position).normalized;
    }

    private void LoadPlayerControl()
    {
        playerControl = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
    }
}
