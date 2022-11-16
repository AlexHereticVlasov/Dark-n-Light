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
    protected PlayerMovement _movement;

    protected OnGroundState(Observation observation, StateMachine machine, Player rigidbody, PlayerMovement movement) : base(observation, machine, rigidbody)
    {
        _movement = movement;
    }

    public override void Update()
    {
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
    public IdleState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player, movement)
    {
    }

    public override void Update()
    {
        base.Update();
        if (_observation.Direction != 0)
        {
            _stateMachine.ChangeState(_player.WalkState);
        }

        _movement.SetXVelocity(0);
    }
}

public class WalkState : OnGroundState
{
    public WalkState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player, movement)
    {
    }

    public override void Update()
    {
        base.Update();
        if (_observation.Direction == 0)
            _stateMachine.ChangeState(_player.IdleState);

        _movement.SetXVelocity(_observation.Direction);

        if (_observation.IsPooshing())
            _stateMachine.ChangeState(_player.PushState);
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
    PlayerMovement _movement;

    public StartJumpState(Observation observation, StateMachine machine, Player rigidbody, PlayerMovement movement) : base(observation, machine, rigidbody)
    {
        _movement = movement;
    }

    public override void Enter()
    {
        base.Enter();
        _movement.Jump(300);
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
            _stateMachine.ChangeState(_player.LandingState);
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
            _stateMachine.ChangeState(_player.IdleState);
    }
}

public class InteractionState : OnGroundState
{
    private float _length;

    public InteractionState(Observation observation, StateMachine machine, Player rigidbody, PlayerMovement movement) : base(observation, machine, rigidbody, movement)
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

public class PushState : OnGroundState
{
    public PushState(Observation observation, StateMachine machine, Player rigidbody, PlayerMovement movement) : base(observation, machine, rigidbody, movement)
    {
    }

    public override void Update()
    {
        base.Update();
        _movement.SetXVelocity(_observation.Direction);

        if (_observation.IsPooshing() == false)
        {
            //ToDo: Different Cases
            _stateMachine.ChangeState(_player.IdleState);

        }
    }
}

public class DeathState : BaseState
{
    private PlayerMovement _movement;

    public DeathState(Observation observation, StateMachine machine, Player rigidbody, PlayerMovement movement) : base(observation, machine, rigidbody)
    {
        _movement = movement;
    }

    public override void Enter()
    {
        base.Enter();
        _movement.SetXVelocity(0);
    }

    public override void Update()
    {
        
    }
}

