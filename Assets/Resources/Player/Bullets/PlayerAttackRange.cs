using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerAttackRange : MonoBehaviour
{
    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void LateUpdate()
    {
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
}
