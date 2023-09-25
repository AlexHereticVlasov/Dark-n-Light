using FinalStateMachine;
using UnityEngine;

public sealed class Stalker : MonoBehaviour
{
    private StateMachine _stateMachine;

    [SerializeField] private StalkerConfig _config;
    [SerializeField] private StalkerMovement _movement;
    [SerializeField] private StalkerBorderPoint[] _borderPoints;
    [SerializeField] private NestPoint _nest;
    [SerializeField] private Player[] _players;

    public SleapStalkerState SleapStalkerState { get; private set; }
    public TrampStalkerState TrampStalkerState { get; private set; }
    public FollowStalkerState FollowStalkerState { get; private set; }
    public MoveToNestStalkerState MoveToNestStalkerState { get; private set; }

    private void Awake() => InitStateMachine();

    private void Update() => _stateMachine.Current.Update();

    private void InitStateMachine()
    {
        _stateMachine = new StateMachine();

        SleapStalkerState = new SleapStalkerState(_stateMachine, this);
        TrampStalkerState = new TrampStalkerState(_stateMachine, _config, _movement, this, _borderPoints);
        FollowStalkerState = new FollowStalkerState(_stateMachine, _config, _movement, this, _players);
        MoveToNestStalkerState = new MoveToNestStalkerState(_stateMachine, _movement, this, _nest);

        _stateMachine.Init(SleapStalkerState);
    }

    public void ReturnToSleep() => _stateMachine.ChangeState(MoveToNestStalkerState);

    public void StartHunt() => _stateMachine.ChangeState(TrampStalkerState);
}
