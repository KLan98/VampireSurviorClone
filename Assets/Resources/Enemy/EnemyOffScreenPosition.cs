using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOffScreenPosition : IEnemyPositionProvider
{
    private float spawnPositionOffset = 5f;
    private Vector2 spawnPos;

    public Vector2 GetOffscreenPosition()
    {
        Vector3 viewPortBottomLeft = new Vector3(0, 0, Camera.main.nearClipPlane);
        Vector3 worldPointBottomLeft = Camera.main.ViewportToWorldPoint(viewPortBottomLeft); // bottom-left corner of the screen in world space
        // Debug.Log($"view port bottom left {viewPortBottomLeft}");
        // Debug.Log($"world point bottom left {worldPointBottomLeft}");

        Vector3 viewPortTopRight = new Vector3(1, 1, Camera.main.nearClipPlane);
        Vector3 worldPointTopRight = Camera.main.ViewportToWorldPoint(viewPortTopRight); // top-right corner of the screen in world space
        // Debug.Log($"view port top right {viewPortTopRight}");
        // Debug.Log($"world point top right {worldPointTopRight}");

        float minX = worldPointBottomLeft.x - spawnPositionOffset;
        // Debug.Log($"MinX {minX}");
        float maxX = worldPointTopRight.x + spawnPositionOffset;
        // Debug.Log($"MaxX {maxX}");
        float minY = worldPointBottomLeft.y - spawnPositionOffset;
        // Debug.Log($"MinY {minY}");
        float maxY = worldPointTopRight.y + spawnPositionOffset;
        // Debug.Log($"MaxY {maxY}");

        int side = Random.Range(0, 4); // 0 = Top, 1 = Bottom, 2 = Left, 3 = Right
        //Debug.Log($"Spawn side = {side}");
        switch (side)
        {
            case 0: // Top
                spawnPos = new Vector3(Random.Range(minX, maxX), maxY, 0);
                break;
            case 1: // Bottom
                spawnPos = new Vector3(Random.Range(minX, maxX), minY, 0);
                break;
            case 2: // Left
                spawnPos = new Vector3(minX, Random.Range(minY, maxY), 0);
                break;
            case 3: // Right
                spawnPos = new Vector3(maxX, Random.Range(minY, maxY), 0);
                break;
        }

        return spawnPos;
    }
}
