using UnityEngine;

public sealed class CoyotityTime : MonoBehaviour
{
    private readonly float _totalLength = 0.12f;

    private float _value = 0;

    private void Update() => _value -= Time.deltaTime;

    public void ResetValue() => _value = _totalLength;

    public void SetValue(float value) => _value = value;

    public bool CanJump() => _value > 0;
}
