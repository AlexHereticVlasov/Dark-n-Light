using System.Collections;
using UnityEngine;

public sealed class CoyotityTime : MonoBehaviour
{
    private readonly float _totalLength = 0.12f;

    private float _value = 0;
    private bool _isLastIsWater = false;

    private void Update() => _value -= Time.deltaTime;

    public void ResetValue()
    {
        if (_isLastIsWater)
        {
            StartCoroutine(RestoreIsOnWater());
            return;
        }

        _value = _totalLength;
    }

    private IEnumerator RestoreIsOnWater()
    {
        yield return new WaitForSeconds(_totalLength * 2);
        _isLastIsWater = false;
    }

    public void SetValue(float value) => _value = value;

    public bool CanJump() => _value > 0;

    internal void SetLastAsWater()
    {
        _isLastIsWater = true;
        
    }
}
