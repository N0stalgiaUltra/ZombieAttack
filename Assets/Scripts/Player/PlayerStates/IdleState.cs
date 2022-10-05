using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private Rigidbody playerRigidbody;
    public IdleState(Rigidbody rigidbody)
    {
        playerRigidbody = rigidbody;
    }
    public override void EnterState(StateManager manager)
    {
        Debug.Log("Idle");

    }


    public override void FixedUpdateState(StateManager manager)
    {
        if (playerRigidbody.velocity.magnitude > 0)
            manager.SwitchState(manager.movingState);
    }

    public override void OnCollisionState(StateManager manager)
    {
        manager.SwitchState(manager.hurtState);
    }

    public override void UpdateState(StateManager manager)
    {
    }
}
