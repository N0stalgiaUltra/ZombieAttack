using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Rigidbody playerRigidbody;

    [SerializeField] private PlayerAnimation playerAnimation;

    private BaseState currentState;
    public IdleState idleState;
    public MovingState movingState;
    public HurtState hurtState;

    #region Events

    

    #endregion
    private void Awake()
    {
        idleState = new IdleState(playerRigidbody);
        movingState = new MovingState(playerRigidbody);
        hurtState = new HurtState(playerAnimation);
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }
    
    // Update is called once per frame
    private void Update()
    {
        currentState.UpdateState(this);
        if (Input.GetKeyDown(KeyCode.K))
            SwitchState(hurtState);
    }

    private void FixedUpdate()
    { 
        currentState.FixedUpdateState(this);
    }
    public void SwitchState(BaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionState(this, collision);
    }

}