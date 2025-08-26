using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHomingBullet 
{
    public void TargetNearestEnemy(GameObject nearestEnemy, PlayerControl playerControl);
}
