using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICirclingBullet 
{
    /// <summary>
    /// Circling around player based on the number of projectiles. Should be called in FixedUpdate
    /// </summary>
    public void RevolveAroundPlayer();
}
