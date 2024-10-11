using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : BaseState
{
    private float _horizontalInput;

    public Movement(MovementSM stateMachine) : base ("Movement", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        //_horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(((MovementSM)stateMachine).idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Debug.Log("moving");
        Vector2 vel = ((MovementSM)stateMachine).rb.velocity;
        vel.x = _horizontalInput * ((MovementSM)stateMachine).speed;
        ((MovementSM)stateMachine).rb.velocity = vel;
    }
}
