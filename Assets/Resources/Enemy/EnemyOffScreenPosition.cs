using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOffScreenPosition : IEnemyPositionProvider
{
    private float spawnPositionOffset = 5f;
    private Vector2 spawnPos;

    public Vector2 GetOffscreenPosition()
    {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)); // bottom-left corner of the screen in world space
        Vector3 topRight   = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane)); // top-right corner of the screen in world space

        float minX = bottomLeft.x - spawnPositionOffset;
        float maxX = topRight.x + spawnPositionOffset;
        float minY = bottomLeft.y - spawnPositionOffset;
        float maxY = topRight.y + spawnPositionOffset;

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
