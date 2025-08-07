using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    public virtual void Enter()
    {
        Debug.Log($"Enter {this} state");
    }

    /// <summary>
    /// What the game does during this state
    /// </summary>
    public virtual void StateBehaviorUpdate()
    {

    }

    public virtual void Exit()
    {
        Debug.Log($"Exit {this} state");
    }
}
