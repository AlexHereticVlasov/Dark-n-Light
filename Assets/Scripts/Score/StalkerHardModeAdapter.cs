using FinalStateMachine;
using UnityEngine;
using UnityEngine.Events;

public sealed class StalkerHardModeAdapter : HardModeAdapter
{
    [SerializeField] private Stalker _stalker;

    public override void Cancel() => _stalker.ReturnToSleep();

    public override void Launch() => _stalker.StartHunt();
}

[CreateAssetMenu(fileName = nameof(StalkerConfig), menuName = nameof(ScriptableObject) + " / " + nameof(StalkerConfig))]
public sealed class StalkerConfig : ScriptableObject
{ 
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float TrampLength { get; private set; }
    [field: SerializeField] public float FollowLength { get; private set; }
}

public sealed class Stalker : MonoBehaviour
{
    private StateMachine _stateMachine;

    [SerializeField] private StalkerConfig _config;
    [SerializeField] private StalkerMovement _movement;
    [SerializeField] private StalkerBorderPoint[] _borderPoints;
    [SerializeField] private NestPoint _nest;

    public SleapStalkerState SleapStalkerState { get; private set; }
    public TrampStalkerState TrampStalkerState { get; private set; }
    public FollowStalkerState FollowStalkerState { get; private set; }
    public MoveToNestStalkerState MoveToNestStalkerState { get; private set; }

    private void Awake() => InitStateMachine();

    private void Update() => _stateMachine.Current.Update();

    private void InitStateMachine()
    {
        _stateMachine = new StateMachine();

        SleapStalkerState = new SleapStalkerState();
        TrampStalkerState = new TrampStalkerState(_config, _movement, _borderPoints);
        FollowStalkerState = new FollowStalkerState(_config, _movement);
        MoveToNestStalkerState = new MoveToNestStalkerState(_movement, _nest);

        _stateMachine.Init(SleapStalkerState);
    }

    public void ReturnToSleep() => _stateMachine.ChangeState(MoveToNestStalkerState);

    public void StartHunt() => _stateMachine.ChangeState(TrampStalkerState);
}

public class StalkerMovement : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; } = 2;

    public void MoveTo(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}

namespace FinalStateMachine
{
    public abstract class BaseStalkerState : BaseState
    {
        protected StateMachine StateMachine;
        protected Stalker Stalker;

        public BaseStalkerState()
        {

        }
    }

    public abstract class MovementStalkerState : BaseStalkerState
    {
        protected StalkerMovement Movement;

        public MovementStalkerState( StalkerMovement movement)
        {
            Movement = movement;
        }
    }

    public abstract class TimedStalkerState : MovementStalkerState
    {
        protected StateTimer Timer;

        public TimedStalkerState(StalkerConfig config, StalkerMovement movement) : base(movement)
        {
            ;
        }

        public override void Enter()
        {
            base.Enter();
            Timer.Reset();
            Timer.TimeOver += OnTimeOver;
        }

        public override void Update() => Timer.Update();

        public override void Exit()
        {
            base.Exit();
            Timer.TimeOver -= OnTimeOver;
        }

        protected abstract void OnTimeOver();
    }

    public sealed class SleapStalkerState : BaseStalkerState
    {
        public override void Update()
        {
            
        }
    }

    public sealed class MoveToNestStalkerState : MovementStalkerState
    {
        private NestPoint _nest;

        public MoveToNestStalkerState(StalkerMovement movement, NestPoint nest) : base(movement)
        {
            _nest = nest;
        }

        public override void Update()
        {
             Movement.MoveTo(_nest.Position);
            
            float deltaSpeed = Movement.Speed * Time.deltaTime;
            float distance = Vector2.Distance(Movement.transform.position, _nest.Position);
            
            if (distance < deltaSpeed)
                StateMachine.ChangeState(Stalker.SleapStalkerState);
        }
    }

    public sealed class TrampStalkerState : TimedStalkerState
    {
        private StalkerBorderPoint[] _stalkerBorderPoints;
        private Vector2 _target;

        public TrampStalkerState(StalkerConfig config, StalkerMovement movement, StalkerBorderPoint[] stalkerBorderPoints) : base(config, movement)
        {
            Timer = new StateTimer(config.TrampLength);
            _stalkerBorderPoints = stalkerBorderPoints;
        }

        public override void Enter()
        {
            base.Enter();
            CalculateTarget();
        }

        public override void Update()
        {
            base.Update();
            Movement.MoveTo(_target);
            CheckIsEnoughCloseToTarget();
        }

        private void CheckIsEnoughCloseToTarget()
        {
            float deltaSpeed = Movement.Speed * Time.deltaTime;
            float distance = Vector2.Distance(Movement.transform.position, _target);

            if (distance < deltaSpeed)
                CalculateTarget();
        }

        protected override void OnTimeOver() => StateMachine.ChangeState(Stalker.FollowStalkerState);

        private void CalculateTarget()
        {
            float x = Random.Range(_stalkerBorderPoints[0].X, _stalkerBorderPoints[1].X); 
            float y = Random.Range(_stalkerBorderPoints[0].Y, _stalkerBorderPoints[1].Y); 
            _target = new Vector2(x, y); 
        }
    }

    public sealed class FollowStalkerState : TimedStalkerState
    {
        private Transform _target;

        public FollowStalkerState(StalkerConfig config, StalkerMovement movement) : base(config, movement)
        {
            Timer = new StateTimer(config.FollowLength);
        }

        public override void Update()
        {
            base.Update();
            Movement.MoveTo(_target.position);
        }

        protected override void OnTimeOver() => StateMachine.ChangeState(Stalker.TrampStalkerState);
    }

    public sealed class StateTimer
    {
        private readonly float _lenght;

        public event UnityAction TimeOver;

        public StateTimer(float lenght) => _lenght = lenght;

        public float Value { get; private set; }

        public void Update()
        {
            Value -= Time.deltaTime;
            if (Value <= 0)
                TimeOver?.Invoke();
        }

        public void Reset() => Value = _lenght;
    }

    public sealed class NestPoint : BasePoint { }

    public sealed class StalkerBorderPoint : BasePoint 
    {
        public float X => Position.x;
        public float Y => Position.y;
    }
}