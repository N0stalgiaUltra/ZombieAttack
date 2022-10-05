using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HurtState : BaseState
{
    private PlayerAnimation playerAnimation;
    public HurtState(PlayerAnimation animation)
    {
        playerAnimation = animation; 
    }
    public override void EnterState(StateManager manager)
    {
        manager.StartCoroutine(HurtPlayer(manager));
    }

    private IEnumerator HurtPlayer(StateManager manager)
    {
        Debug.Log("Start coroutine");
        playerAnimation.Hurt();
        Debug.Log(playerAnimation.EndHurtAnim);
        yield return new WaitForSeconds(playerAnimation.EndHurtAnim);
        manager.SwitchState(manager.idleState);
    }
    public override void FixedUpdateState(StateManager manager)
    {
    }

    public override void OnCollisionState(StateManager manager, Collision collision)
    {
    }

    public override void UpdateState(StateManager manager)
    {
    }

    
}
