using UnityEngine;

public sealed class WindEffect : BaseZoneEffect
{
    private readonly float _minForce = 0.4f;
    private readonly float _power = 9.81f * 1.2f;

    [SerializeField] private Vector2 _direction = Vector2.up;
    [SerializeField] private AnimationCurve _curve;

    private float _time;

    private void Update() => _time = Mathf.PingPong(Time.time, 2);

    public override void Apply(Player player) => player.AddForce(_direction * (_power * (_minForce + _curve.Evaluate(_time))));
}
