using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerAttackRange : MonoBehaviour
{
    private BoxCollider2D box;
    private float placeHolderMinDistance = 100;

    [SerializeField] private List<GameObject> inRangeEnemies;
    public List<GameObject> InRangeEnemies => inRangeEnemies;
    public GameObject nearestEnemy;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        GetNearestEnemy();
    }

    private void LateUpdate()
    {
        // TODO revamp this camera system
        Camera cam = Camera.main;

        // Calculate screen size in world units
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        // Update collider size
        box.size = new Vector2(width, height);
        box.offset = Vector2.zero;

        // Follow camera position
        transform.position = cam.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        inRangeEnemies.Add(enemyCollider.gameObject);
    }

    private void OnTriggerExit2D(Collider2D enemyCollider)
    {
        inRangeEnemies.Remove(enemyCollider.gameObject);
    }

    private void GetNearestEnemy()
    {
        float distanceToEnemy;
        float minDistance = placeHolderMinDistance;

        foreach(GameObject enemy in inRangeEnemies)
        {
            distanceToEnemy = Vector2.Distance(this.gameObject.transform.position, enemy.transform.position);
            //Debug.Log($"Distance to {enemy} = {distanceToEnemy}");
            
            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
    }
}
