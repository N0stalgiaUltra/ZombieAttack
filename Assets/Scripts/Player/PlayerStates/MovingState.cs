using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : BaseState
{
    public delegate void MovingPlayer();
    public static event MovingPlayer OnMove;

    public override void EnterState(StateManager manager)
    {
        Debug.Log("Moving");
    }

    public override void FixedUpdateState(StateManager manager)
    {
        OnMove?.Invoke();
    }

    public override void OnCollisionState(StateManager manager)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(StateManager manager)
    {
        throw new System.NotImplementedException();
    }
}
