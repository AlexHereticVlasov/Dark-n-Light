using UnityEngine;
using UnityEngine.Events;
using FinalStateMachine;

public class Player : MonoBehaviour, IDamageable, IActor, IEffectOrigin
{
    [SerializeField] private Observation _observation;
    [SerializeField] private PlayerMovement _movement;

    private StateMachine _stateMachine;

    public event UnityAction Selected;
    public event UnityAction Deselected;
    public event UnityAction Death;
    public event UnityAction<Elements> Spawned;

    public IdleState IdleState { get; private set; }
    public WalkState WalkState { get; private set; }
    public StartJumpState StartJumpState { get; private set; }
    public InAirState InAirState { get; private set; }
    public LandingState LandingState { get; private set; }
    public InteractionState InteractionState { get; private set; }
    public PushState PushState { get; private set; }
    public DeathState DeathState { get; private set; }
    public LevitationState IdleLevitationState { get; private set; }
    public LevitationState MoveLevitationState { get; private set; }
    public LevelCompliteState LevelCompliteState { get; private set; }
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
        IdleLevitationState = new IdleLevitationState(_observation, _stateMachine, this, _movement);
        MoveLevitationState = new MoveLevitationState(_observation, _stateMachine, this, _movement);
        LevelCompliteState = new LevelCompliteState(_observation, _stateMachine, this, _movement);

        _stateMachine.Init(IdleState);
    }

    private void Update() => _stateMachine.Current.Update();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out WindEffect effect))
            _stateMachine.ChangeState(IdleLevitationState);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out WindEffect effect))
            _stateMachine.ChangeState(InAirState);
    }

    public void Select() => Selected?.Invoke();

    public void Deselect() => Deselected?.Invoke();

    public void TakeDamage()
    {
        if (_stateMachine.Current == LevelCompliteState) return;

        if (_stateMachine.Current != DeathState)
            Die();
    }

    private void Die()
    {
        _stateMachine.ChangeState(DeathState);
        Spawned?.Invoke(Element);
        Death?.Invoke();
    }

    public void AddForce(Vector2 force) => _movement.AddForce(force);

    public void Warp() => _stateMachine.ChangeState(LevelCompliteState);
}
