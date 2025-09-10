using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Default behavior for bullets: fly straight
/// </summary>
public interface IDefaultBehavior
{
    /// <summary>
    /// Fly in the direction of Vector2.up
    /// </summary>
    public void FlyStraight(Vector2 direction);
}
