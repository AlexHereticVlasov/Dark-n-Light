using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerHealthView : MonoBehaviour
{
    private const float LerpFactor = 0.03125f;

    [SerializeField] private PlayerUIPresenter _healthPresenter;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _aditionalBar;

    private Coroutine _change;

    private void OnEnable() => _healthPresenter.ValueChanged += OnHealthChanged;

    private void OnDisable() => _healthPresenter.ValueChanged -= OnHealthChanged;

    private void OnHealthChanged(float value)
    {
        if (_change is not null)
            StopCoroutine(_change);

        _aditionalBar.value = value;
        _change = StartCoroutine(ChangeValue(value));
    }

    private IEnumerator ChangeValue(float target)
    {
        while (_healthBar.value != target)
        {
            _healthBar.value = Mathf.Lerp(_healthBar.value, target, LerpFactor);
            yield return null;
        }

        _change = null;
    }
}
