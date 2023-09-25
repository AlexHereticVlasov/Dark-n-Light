using UnityEngine;

public interface IBazier
{
    Transform Transform { get; }
    Vector2 GetPosition(Vector2 start, float t);
}

public sealed class BazierCurve : MonoBehaviour, IBazier
{
    [SerializeField] private BazierPoint[] _points;

    public Transform Transform => transform;

    public Vector2 GetPosition(Vector2 start, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1 - t;

        return oneMinusT * oneMinusT * oneMinusT * start +
            3 * oneMinusT * oneMinusT * t * _points[0].Position +
            3 * oneMinusT * t * t * _points[1].Position +
            t * t * t * _points[2].Position; ;
    }
}
