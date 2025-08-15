using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyPositionProvider 
{
    Vector2 GetOffscreenPosition(Vector2 bounds, Vector3 camPos);
}
