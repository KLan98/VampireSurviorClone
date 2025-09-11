using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handle damage receiving & currentHealth update
public class PlayerDamageReceiver : MonoBehaviour
{
    // components
    private DamageCalculator damageCalculator;
    [SerializeField] private PlayerStats playerStats;

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
            return playerStats.MaxHealth;
        }
    }
    
    // private fields
    private int counter;
    private int maxCounter;
    [SerializeField] private int currentHealth;

    private void Start()
    {
        damageCalculator = new DamageCalculator(playerStats);

        // init stats
        currentHealth = playerStats.MaxHealth;
        // Debug.Log($"Player init health = {currentHealth}, with max health stat = {playerStats.MaxHealth}");  
    }

    private void Awake()
    {
        // init physics update counter
        maxCounter = 5;
        counter = maxCounter;
        // Debug.Log($"[{gameObject.name}] Init value of counter = {counter}, maxCounter = {maxCounter}");  
    }

    public PlayerDamageReceiver(PlayerStats playerStats)
    {
        this.playerStats = playerStats;
    }

    public void PlayerGotHitBy(EnemyController enemyController)
    {
        int enemyDamage = enemyController.enemyStats.Damage;
        currentHealth = currentHealth - damageCalculator.DamageDealtToPlayer(enemyDamage);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyController>())
        {
            counter = counter - 1;
            if (counter <= 0)
            {
                EnemyController enemyInRange = collider.GetComponent<EnemyController>();

                PlayerGotHitBy(enemyInRange);

                // Debug.Log($"Player current health = {currentHealth}");
                // Debug.Log($"Player got hit by {enemyInRange}");

                counter = maxCounter;
            }
        }
    }
}
