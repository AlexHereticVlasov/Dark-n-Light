using UnityEngine;
using UnityEngine.Events;

//ToDo: Fix pivot position calculation and Change position logic
public sealed class Liver : MonoBehaviour
{
    private const float MinOffset = -0.45f;
    private const float MaxOffset = 0.45f;

    private Vector3 _previousPosition;

    public event UnityAction<float> PositionChanged;

    private void Start() => _previousPosition = transform.localPosition;

    public void SetPosition(float x)
    {
        x = Mathf.Clamp(x, MinOffset, MaxOffset);
        transform.localPosition = new Vector2(x, transform.localPosition.y);
        _previousPosition = transform.localPosition;
    }

    private void FixedUpdate()
    {
        if (_previousPosition == transform.localPosition) return;

        _previousPosition = transform.position;

        float x = transform.localPosition.x;
        x = Mathf.Clamp(x, MinOffset, MaxOffset);
        transform.localPosition = new Vector2(x, transform.localPosition.y);
        PositionChanged?.Invoke(x);
    }
}
