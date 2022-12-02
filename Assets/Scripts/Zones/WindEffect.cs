using UnityEngine;
using UnityEngine.Events;

public class WindEffect : BaseZoneEffect
{
    private readonly float _minForce = 0.4f;
    private readonly float _power = 9.81f * 1.2f;

    [SerializeField] private Vector2 _direction = Vector2.up;
    [SerializeField] private AnimationCurve _curve;

    private float _time;


    private void Update() => _time = Mathf.PingPong(Time.time, 2);

    public override void Apply(Player player) => player.AddForce(_direction * (_power * (_minForce + _curve.Evaluate(_time))));
}

[System.Serializable]
public class Exit
{
    [SerializeField] private Elements _element;

    public event UnityAction StateChanged;

    public bool IsInside { get; private set; }

    [field: SerializeField] public LevelEndExitEffect ExitEffect { get; private set; }
    [field: SerializeField] public LevelEndEnterEffect EnterEffect { get; private set; }

    public void Init()
    {
        EnterEffect.PlayerInside += OnPlayerInside;
        ExitEffect.Playeroutside += OnPlayeroutside;
    }

    public void Disable()
    {
        EnterEffect.PlayerInside -= OnPlayerInside;
        ExitEffect.Playeroutside -= OnPlayeroutside;
    }

    private void OnPlayeroutside(Player player)
    {
        if (player.Element != _element) return;
        
        IsInside = false;
        StateChanged?.Invoke();
    }

    private void OnPlayerInside(Player player)
    {
        if (player.Element != _element) return;

        IsInside = true;
        StateChanged?.Invoke();
    }
}
