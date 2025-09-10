using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schaufel : BulletWithTimeout
{
    [SerializeField] private PlayerControl playerControl;

    private IDefaultBehavior defaultBehavior;
    private IFlyInDirectionOfPlayer schaufelBehavior;
    private Vector2 direction;

    private void Start()
    {
        defaultBehavior = new BehaviorDefault(this);
        schaufelBehavior = new BehaviorFlyInDirectionOfPlayer(this, playerControl);
        direction = schaufelBehavior.GetBulletDirection();
        schaufelBehavior.FlipBulletSprite(schaufelBehavior.GetPlayerDirection());
    }

    private void FixedUpdate()
    {
        defaultBehavior.FlyStraight(direction);
    }

    protected override void TriggerReturnToPool()
    {
        SchaufelBulletPool.Instance.ReturnToPool(this);
        base.TriggerReturnToPool();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

        if (enemyController != null)
        {
            TriggerReturnToPool();
        }

        else
        {
            return;
        }
    }
}
