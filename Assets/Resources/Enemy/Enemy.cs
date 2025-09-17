using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void InitPosition(Vector2 spawnPosition)
    {
        //Debug.Log($"Parameter spawnPosition = {spawnPosition}");
        this.gameObject.transform.position = spawnPosition;
        //Debug.Log($"Game object {this} spawned at {rb.position}");
    }

    public virtual void TriggerReturnToPool()
    {
        Debug.Log($"{this} returned to pool");
    }
}
