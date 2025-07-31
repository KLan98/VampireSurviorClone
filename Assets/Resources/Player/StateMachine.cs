using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public State currentState;

    public void InitState(State initState)
    {
        currentState = initState;
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
