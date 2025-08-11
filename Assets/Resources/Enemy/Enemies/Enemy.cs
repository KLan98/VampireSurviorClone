using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void InitPosition(Vector2 spawnPosition)
    {
        this.gameObject.transform.position = spawnPosition;
    }

    protected virtual void TriggerReturnToPool()
    {

    }
}
