using UnityEngine;
using UnityEngine.Events;

public sealed class StalkerHardModeAdapter : HardModeAdapter
{
    [SerializeField] private Stalker _stalker;

    public override void Cancel() => _stalker.ReturnToSleep();

    public override void Launch() => _stalker.StartHunt();
}

namespace FinalStateMachine
{
    public abstract class BaseStalkerState : BaseState
    {
        protected StateMachine StateMachine;
        protected Stalker Stalker;

        public BaseStalkerState(StateMachine stateMachine, Stalker stalker)
        {
            StateMachine = stateMachine;
            Stalker = stalker;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log(this.GetType());
        }
    }

    public abstract class MovementStalkerState : BaseStalkerState
    {
        protected StalkerMovement Movement;

        public MovementStalkerState(StateMachine stateMachine, StalkerMovement movement, Stalker stalker) : base(stateMachine, stalker)
        {
            
            Movement = movement;
            Debug.Log(stalker == null);
        }
    }

    public abstract class TimedStalkerState : MovementStalkerState
    {
        protected StateTimer Timer;

        public TimedStalkerState(StateMachine stateMachine, StalkerConfig config, StalkerMovement movement, Stalker stalker) : base(stateMachine, movement, stalker)
        {
            ;
        }

        public override void Enter()
        {
            Timer.Reset();
            Timer.TimeOver += OnTimeOver;
            base.Enter();
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
        public SleapStalkerState(StateMachine stateMachine, Stalker stalker) : base(stateMachine, stalker)
        {
        }

        public override void Update()
        {
            
        }
    }

    public sealed class MoveToNestStalkerState : MovementStalkerState
    {
        private NestPoint _nest;

        public MoveToNestStalkerState(StateMachine stateMachine, StalkerMovement movement, Stalker stalker, NestPoint nest) : base(stateMachine, movement, stalker)
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

        public TrampStalkerState(StateMachine stateMachine, StalkerConfig config, StalkerMovement movement, Stalker stalker, StalkerBorderPoint[] stalkerBorderPoints) : base(stateMachine, config, movement, stalker)
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
        private Player[] _players;
        private Transform _target;

        public FollowStalkerState(StateMachine stateMachine, StalkerConfig config, StalkerMovement movement, Stalker stalker, Player[] players) : base(stateMachine, config, movement, stalker)
        {
            Timer = new StateTimer(config.FollowLength);
            _players = players;
        }

        public override void Enter()
        {
            _target = _players[Random.Range(0, _players.Length)].transform;
            base.Enter();
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
}