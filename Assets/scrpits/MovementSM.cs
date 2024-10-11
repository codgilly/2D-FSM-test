using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StatesMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Movement moveState;

    public Rigidbody2D rb;
    public float speed = 4f;

    public void Awake()
    {
        idleState = new Idle(this);
        moveState = new Movement(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

}
