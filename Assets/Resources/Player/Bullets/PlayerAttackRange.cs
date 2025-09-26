using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerAttackRange : MonoBehaviour
{
    private BoxCollider2D attackRange;
    private float playerAttackRangeWidth;
    private float playerAttackRangeHeight;
    private float placeHolderMinDistance = 100;

    [SerializeField] private List<EnemyController> inRangeEnemies;
    public List<EnemyController> InRangeEnemies => inRangeEnemies;
    public EnemyController nearestEnemy;

    private void Awake()
    {
        LoadBoxCollider();

        Vector3 viewPortTopRight = new Vector3(1, 1, Camera.main.nearClipPlane);
        Vector3 worldPointTopRight = Camera.main.ViewportToWorldPoint(viewPortTopRight); // top-right corner of the 
        // Debug.Log($"world point top right {worldPointTopRight}");

        playerAttackRangeHeight = 2 * Mathf.Abs(worldPointTopRight.y);
        playerAttackRangeWidth = 2 * Mathf.Abs(worldPointTopRight.x);

        attackRange.size = new Vector2(playerAttackRangeWidth, playerAttackRangeHeight);
    }

    private void FixedUpdate()
    {
        GetNearestEnemy();
    }

    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        EnemyController enemyController = enemyCollider.gameObject.GetComponent<EnemyController>();

        if (enemyController == null)
        {
            return;
        }

        inRangeEnemies.Add(enemyController);
    }

    private void OnTriggerExit2D(Collider2D enemyCollider)
    {        
        EnemyController enemyController = enemyCollider.gameObject.    GetComponent<EnemyController>();

        if (enemyController == null)
        {
            return;
        }

        inRangeEnemies.Remove(enemyController);
    }

    private void GetNearestEnemy()
    {
        float distanceToEnemy;
        float minDistance = placeHolderMinDistance;

        foreach(EnemyController enemy in inRangeEnemies)
        {
            distanceToEnemy = Vector2.Distance(this.gameObject.transform.position, enemy.gameObject.transform.position);
            //Debug.Log($"Distance to {enemy} = {distanceToEnemy}");
            
            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
    }

    private void LoadBoxCollider()
    {
        attackRange = gameObject.GetComponent<BoxCollider2D>();
    }
}
