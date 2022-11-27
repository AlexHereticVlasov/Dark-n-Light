using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IActor
{
    [SerializeField] private Observation _observation;
    [SerializeField] private PlayerMovement _movement;

    private StateMachine _stateMachine;
    public IdleState IdleState { get; private set; }
    public WalkState WalkState { get; private set; }
    public StartJumpState StartJumpState { get; private set; }
    public InAirState InAirState { get; private set; }
    public LandingState LandingState { get; private set; }
    public InteractionState InteractionState { get; private set; }
    public PushState PushState { get; private set; }
    public DeathState DeathState { get; private set; }

    [field: SerializeField] public Elements Element { get; private set; } = Elements.Dark;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        IdleState = new IdleState(_observation, _stateMachine, this, _movement);
        WalkState = new WalkState(_observation, _stateMachine, this, _movement);
        StartJumpState = new StartJumpState(_observation, _stateMachine, this, _movement);
        InAirState = new InAirState(_observation, _stateMachine, this);
        LandingState = new LandingState(_observation, _stateMachine, this);
        InteractionState = new InteractionState(_observation, _stateMachine, this, _movement);
        PushState = new PushState(_observation, _stateMachine, this, _movement);
        DeathState = new DeathState(_observation, _stateMachine, this, _movement);

        _stateMachine.Init(IdleState);
    }

    private void Update() => _stateMachine.Current.Update();

    public void TakeDamage()
    {
        _stateMachine.ChangeState(DeathState);
    }

    public void AddForce(Vector2 force) => _movement.AddForce(force);
}
