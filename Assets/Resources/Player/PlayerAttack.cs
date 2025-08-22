using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerControl playerControl;
    private float timeCounter;

    //[SerializeField] private EnemyController nearestEnemy;
    //public EnemyController NearestEnemy => nearestEnemy;

    private void Awake()
    {
        LoadPlayerControl();
    }

    private void Update()
    {
        foreach (SlotClass slot in playerControl.inventoryManager.ItemDB)
        {
            if (slot == null)
            {
                return;
            }

            WeaponClass weapon = slot.GetItem() as WeaponClass; // cast 

            if (weapon == null)
            {
                Debug.LogWarning($"{weapon} is not a weapon");
                return;
            }

            timeCounter = timeCounter + Time.deltaTime;

            if (timeCounter >= weapon.CoolDownTime)
            {
                for(int i = 0; i < weapon.NumberOfProjectiles; i++)
                {
                    SpawnAttack(weapon);
                }
                timeCounter = 0f;
            }
        }
    }

    // Player attack should reference inventory Manager through player Control
    private void LoadPlayerControl()
    {
        playerControl = gameObject.GetComponentInParent<PlayerControl>();
    }

    private void SpawnAttack(WeaponClass weapon)
    {
        // if the bullet is homing the bullet spawnDirection = direction of nearest enemy
        if (weapon.ItemName == "Shotgun")
        {
            ShotgunBulletPool.Instance.SpawnBullet(this.gameObject.transform.position, new Vector2(1, 1));
            //Debug.Log($"{weapon} spawned");
        }

        if (weapon.ItemName == "Heugabel")
        {
            HeugabelBulletPool.Instance.SpawnBullet(this.gameObject.transform.position, new Vector2(1, 1));
        }

        if (weapon.ItemName == "Sichel")
        {
            SichelBulletPool.Instance.SpawnBullet(this.gameObject.transform.position, new Vector2(0, 1));
            //Debug.Log($"{weapon} spawned");
        }

        if (weapon.ItemName == "Schaufel")
        {
            SchaufelBulletPool.Instance.SpawnBullet(this.gameObject.transform.position, new Vector2(1, 0));
        }
    }

    //private Vector2 DistanceToNearestEnemy()
    //{

    //    return
    //}

    //public virtual void FindNearestEnemy()
    //{
    //    // local variable shouldn't use as [SerializeField] & global variable
    //    float distanceToEnemy;
    //    float nearestDistance = Mathf.Infinity;

    //    // calculate distance to each in range enemy
    //    foreach (EnemyController enemy in this.inRangeEnemies)
    //    {
    //        distanceToEnemy = Vector3.Distance(gameObject.transform.position, enemy.transform.position);

    //        if (distanceToEnemy < nearestDistance)
    //        {
    //            this.nearestEnemy = enemy;
    //            nearestDistance = distanceToEnemy;
    //        }
    //    }
    //}
}
