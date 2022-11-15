using UnityEngine;

public class StateMachine
{
    public BaseState Current { get; private set; }

    public void Init(BaseState state)
    {
        Current = state;
        Current.Enter();
    }

    public void ChangeState(BaseState state)
    {
        Current.Exit();
        Current = state;
        Current.Enter();
    }
}

public abstract class BaseState
{
    protected Observation _observation;
    protected StateMachine _stateMachine;
    protected Player _player;

    public BaseState(Observation observation, StateMachine machine, Player rigidbody)
    {
        _observation = observation;
        _stateMachine = machine;
        _player = rigidbody;
    }

    public virtual void Enter()
    {
        Debug.Log($"Enter {this}");
        //ToDo: Start Animation Here
    }

    public abstract void Update();
        
    public virtual void Exit()
    {
        Debug.Log(nameof(Exit));
        //ToDo: EndAnimation
    }
}
public abstract class OnGroundState : BaseState
{
    protected OnGroundState(Observation observation, StateMachine machine, Player rigidbody) : base(observation, machine, rigidbody)
    {
    }

    public override void Update()
    {
        //ToDo: Remove to BaseGroundState
        if (_observation.IsJumping)
        {
            _observation.SetIsJumping(false);
            _stateMachine.ChangeState(_player.StartJumpState);
            return;
        }
    }
}
public class IdleState : OnGroundState 
{
    public IdleState(Observation observation, StateMachine machine, Player player) : base(observation, machine, player)
    {
    }

    public override void Update()
    {
        base.Update();
        if (_observation.Direction != 0)
        {
            _stateMachine.ChangeState(_player.WalkState);
        }

        _player.SetXVelocity(0);
    }
}

public class WalkState : OnGroundState
{
    public WalkState(Observation observation, StateMachine machine, Player player) : base(observation, machine, player)
    {
    }

    public override void Update()
    {
        base.Update();
        if (_observation.Direction == 0)
        {
            _stateMachine.ChangeState(_player.IdleState);
        }

        _player.SetXVelocity(_observation.Direction);
    }
}
public abstract class JumpState : BaseState
{
    protected JumpState(Observation observation, StateMachine machine, Player rigidbody) : base(observation, machine, rigidbody)
    {
    }
}

public class StartJumpState : JumpState
{
    public StartJumpState(Observation observation, StateMachine machine, Player rigidbody) : base(observation, machine, rigidbody)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.Jump(300);
    }

    public override void Update()
    {
        if (_observation.IsOnEarth() == false) // ToDo: Use Polymorph
            _stateMachine.ChangeState(_player.InAirState);
    }
}

public class InAirState : JumpState
{
    public InAirState(Observation observation, StateMachine machine, Player rigidbody) : base(observation, machine, rigidbody)
    {
    }

    public override void Update()
    {
        //ToDO: Move in Air?

        if (_observation.IsOnEarth())
        {
            _stateMachine.ChangeState(_player.LandingState);
        }
    }
}
public class LandingState : JumpState
{
    public LandingState(Observation observation, StateMachine machine, Player rigidbody) : base(observation, machine, rigidbody)
    {
    }

    public override void Update()
    {
        if (_observation.IsOnEarth())
        {
            _stateMachine.ChangeState(_player.IdleState);
        }
    }
}

public class InteractionState : OnGroundState
{
    private float _length;


    public InteractionState(Observation observation, StateMachine machine, Player rigidbody) : base(observation, machine, rigidbody)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Hack: Temp Solituon, get length from animation
        _length = 0.5f;
    }

    public override void Update()
    {
        base.Update();
        _length -= Time.deltaTime;
        if (_length <= 0)
        {
            _stateMachine.ChangeState(_player.IdleState);
        }
    }
}

