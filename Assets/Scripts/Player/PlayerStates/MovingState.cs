using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : BaseState
{
    public delegate void MovingPlayer();
    public static event MovingPlayer OnMove;
    private Rigidbody playerRigidbody;

    public MovingState(Rigidbody rigidbody)
    {
        this.playerRigidbody = rigidbody;
    }

    public override void EnterState(StateManager manager)
    {
    }

    public override void FixedUpdateState(StateManager manager)
    {
        OnMove?.Invoke();

        if (playerRigidbody.velocity.magnitude.Equals(0))
            manager.SwitchState(manager.idleState);
    }

    public override void OnCollisionState(StateManager manager, Collision collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(StateManager manager)
    {
    }
}
