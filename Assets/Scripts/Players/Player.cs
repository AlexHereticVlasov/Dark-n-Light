using UnityEngine;
using UnityEngine.Events;
using FinalStateMachine;

//TODO: Separate this class to different interfaces
public class Player : MonoBehaviour, IHeliable, IActor, IEffectOrigin
{
    [SerializeField] private Observation _observation;
    [SerializeField] private PlayerMovement _movement;

    [SerializeField] private PlayerSettings[] _configs;

    private StateMachine _stateMachine;
    public Health Health { get; private set; }

    public event UnityAction Selected;
    public event UnityAction Deselected;
    public event UnityAction Unlished;
    public event UnityAction Captured;
    public event UnityAction<Vector2> Death;
    public event UnityAction<Elements, Vector2> Spawned;
    public event UnityAction<float, float> HealthChanged;

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
        //Hack: Temp Solution, create health here. Get value from save data
        Health = new Health(5);


        InitializeStateMachine();
        gameObject.layer = _configs[(int)Element].Layer;
    }

    private void InitializeStateMachine()
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

    public void Heal(float amount) => Health.Heal(amount);

    public void TakeDamage(float amount)
    {
        if (_stateMachine.Current == LevelCompliteState) return;
        Health.TakeDamage(amount); //Hack: Temp Solutin
        TryDie();
    }

    private bool CanDie() => _stateMachine.Current != DeathState && Health.Value <= 0;

    private void TryDie()
    {
        if (CanDie())
        {
            _stateMachine.ChangeState(DeathState);
            Spawned?.Invoke(Element, transform.position);
            Death?.Invoke(transform.position);
        }
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

    public void SetIsJumpAble(bool value) => _observation.SetIsJumpAble(value);
}

public sealed class Health
{
    private readonly int _max;

    public float Value { get; private set; }

    public event UnityAction<float, float> ValueChanged;

    public Health(int value)
    {
        _max = value;
        Value = value;
    }

    public void Heal(float amount)
    {
        Value += amount;
        Value = Mathf.Clamp(Value, 0, _max);
        ValueChanged?.Invoke(Value, _max);
    }

    public void TakeDamage(float amount)
    {
        //if (_stateMachine.Current == LevelCompliteState) return;
        if (Value <= 0) return;

        Value -= amount;
        ValueChanged?.Invoke(Value, _max);

        //ToDo: Death event
        //if (CanDie())
        //    Die();
    }
}
