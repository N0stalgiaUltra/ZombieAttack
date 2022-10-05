using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(StateManager manager);
    public abstract void UpdateState(StateManager manager);
    public abstract void FixedUpdateState(StateManager manager);
    public abstract void OnCollisionState(StateManager manager);
}
