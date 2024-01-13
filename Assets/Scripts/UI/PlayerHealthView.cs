using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private PlayerUIPresenter _healthPresenter;
    [SerializeField] private Slider _healthBar;

    private void OnEnable() => _healthPresenter.ValueChanged += OnHealthChanged;

    private void OnDisable() => _healthPresenter.ValueChanged -= OnHealthChanged;

    private void OnHealthChanged(float value) => _healthBar.value = value;
}
