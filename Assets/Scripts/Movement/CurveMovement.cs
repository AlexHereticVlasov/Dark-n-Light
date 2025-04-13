using UnityEngine;

public sealed class CurveMovement : BaseMovement
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Path _path;
    [SerializeField] private float _speedModifier = 0.2f;

    protected override void Move()
    {
        float delta = _curve.Evaluate(Time.time * _speedModifier);
        transform.position = Vector2.Lerp(_path.GetPoint(0), _path.GetPoint(1), delta);
    }

}