using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Observation _observation;
    [SerializeField] private Rigidbody2D _rigidbody;


    //ToDo: Create Stats class

    [SerializeField] private float _speed = 3;

    private StateMachine _stateMachine;
    public IdleState IdleState { get; private set; }
    public WalkState WalkState { get; private set; }
    public StartJumpState StartJumpState { get; private set; }
    public InAirState InAirState { get; private set; }
    public LandingState LandingState { get; private set; }
    public InteractionState InteractionState { get; private set; }


    private void Awake()
    {
        _stateMachine = new StateMachine();

        IdleState = new IdleState(_observation, _stateMachine, this);
        WalkState = new WalkState(_observation, _stateMachine, this);
        StartJumpState = new StartJumpState(_observation, _stateMachine, this);
        InAirState = new InAirState(_observation, _stateMachine, this);
        LandingState = new LandingState(_observation, _stateMachine, this);
        InteractionState = new InteractionState(_observation, _stateMachine, this);

        _stateMachine.Init(IdleState);
    }

    private void Update()
    {
        _stateMachine.Current.Update();
    }

    public void SetXVelocity(float value) => _rigidbody.velocity = new Vector2(value * _speed, _rigidbody.velocity.y);

    public void Jump(int value) => _rigidbody.AddForce(Vector2.up * value);
}
