using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : MonoBehaviour
{
    // components
    private EnemyDamageCalculator damageCalculator;
    [SerializeField] private EnemyStats enemyStats;

    // properties
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    public int MaxHealth
    {
        get
        {
            return enemyStats.MaxHealth;
        }
    }
    
    // private fields
    [SerializeField] private int currentHealth;

    private void Start()
    {
        damageCalculator = new EnemyDamageCalculator(enemyStats);

        // init stats
        currentHealth = enemyStats.MaxHealth;
        // Debug.Log($"Enemy init health = {currentHealth}, with max health stat = {enemyStats.MaxHealth}");  
    }

    public EnemyDamageReceiver(EnemyStats enemyStats)
    {
        this.enemyStats = enemyStats;
    }

    public void EnemyGotHitBy(Bullet bullet)
    {
        int bulletDamage = bullet.WeaponClass.InitDamage;

        currentHealth = currentHealth - damageCalculator.DamageDealtToEnemy(bulletDamage);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Bullet>())
        {
            Bullet bullet = collider.GetComponent<Bullet>();

            EnemyGotHitBy(bullet);

            Debug.Log($"{this.gameObject.transform.parent.name} current health = {currentHealth}");
            Debug.Log($"{this.name} got hit by {bullet}");
        }
    }
}
