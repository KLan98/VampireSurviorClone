using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOffScreenPosition : IEnemyPositionProvider
{
    private float spawnPositionOffset = 2f;

    public Vector2 GetOffscreenPosition(Vector2 bounds, Vector3 camPos)
    {
        float x = 0f, y = 0f;
        int side = Random.Range(0, 4); // 0 = Top, 1 = Bottom, 2 = Left, 3 = Right
        //Debug.Log($"Spawn side = {side}");
        switch (side)
        {
            case 0: // Top
                x = Random.Range(camPos.x - bounds.x, camPos.x + bounds.x);
                y = camPos.y + bounds.y + spawnPositionOffset;
                break;
            case 1: // Bottom
                x = Random.Range(camPos.x - bounds.x, camPos.x + bounds.x);
                y = camPos.y - bounds.y - spawnPositionOffset;
                break;
            case 2: // Left
                x = camPos.x - bounds.x - spawnPositionOffset;
                y = Random.Range(camPos.y - bounds.y, camPos.y + bounds.y);
                break;
            case 3: // Right
                x = camPos.x + bounds.x + spawnPositionOffset;
                y = Random.Range(camPos.y - bounds.y, camPos.y + bounds.y);
                break;
        }

        return new Vector2(x, y);
    }
}
