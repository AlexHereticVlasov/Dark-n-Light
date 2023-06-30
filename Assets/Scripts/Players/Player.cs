using UnityEngine;
using UnityEngine.Events;
using FinalStateMachine;

public class Player : MonoBehaviour, IDamageable, IActor, IEffectOrigin
{
    [SerializeField] private Observation _observation;
    [SerializeField] private PlayerMovement _movement;

    [SerializeField] private PlayerSettings[] _configs;

    private StateMachine _stateMachine;

    public event UnityAction Selected;
    public event UnityAction Deselected;
    public event UnityAction Unlished;
    public event UnityAction Captured;
    public event UnityAction Death;
    public event UnityAction<Elements, Vector2> Spawned;

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
    public InPrisonState InPrisonState { get; private set; }

    [field: SerializeField] public Elements Element { get; private set; } = Elements.Dark;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        var config = _configs[(int)Element];

        IdleState = new IdleState(_observation, _stateMachine, this, _movement, config);
        WalkState = new WalkState(_observation, _stateMachine, this, _movement, config);
        StartJumpState = new StartJumpState(_observation, _stateMachine, this, _movement, config);
        InAirState = new InAirState(_observation, _stateMachine, this, _movement, config);
        LandingState = new LandingState(_observation, _stateMachine, this, _movement, config);
        InteractionState = new InteractionState(_observation, _stateMachine, this, _movement, config);
        PushState = new PushState(_observation, _stateMachine, this, _movement, config);
        DeathState = new DeathState(_observation, _stateMachine, this, _movement, config);
        IdleLevitationState = new IdleLevitationState(_observation, _stateMachine, this, _movement, config);
        MoveLevitationState = new MoveLevitationState(_observation, _stateMachine, this, _movement, config);
        LevelCompliteState = new LevelCompliteState(_observation, _stateMachine, this, _movement, config);
        InPrisonState = new InPrisonState(_observation, _stateMachine, this, _movement, config);

        _stateMachine.Init(IdleState);
    }

    private void Update() => _stateMachine.Current.Update();

    private void FixedUpdate()
    {
        if (_observation.IsOnIce && Element == Elements.Fire)
            _movement.AddForce(new Vector2(0, -9.81f * 40));
    }

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
        Spawned?.Invoke(Element, transform.position);
        Death?.Invoke();
    }

    public void AddForce(Vector2 force) => _movement.AddForce(force);

    public void Warp() => _stateMachine.ChangeState(LevelCompliteState);

    public void SetIsOnIce(bool value) => _observation.SetIsOnIce(value);

    public void Unlish()
    {
        _movement.Unfreaze();
        _stateMachine.ChangeState(IdleState);
        Unlished?.Invoke();
        transform.SetParent(null);
    }

    public void Capture()
    {
        _movement.Freaze();
        _stateMachine.ChangeState(InPrisonState);
        Captured?.Invoke();
    }
}
