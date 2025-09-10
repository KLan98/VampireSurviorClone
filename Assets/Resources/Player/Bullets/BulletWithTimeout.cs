using UnityEngine;

public class BulletWithTimeout : Bullet
{
    protected float bulletTimeout = 8.0f;

    protected void OnEnable()
    {
        Invoke(nameof(TriggerReturnToPool), bulletTimeout);
    }
}