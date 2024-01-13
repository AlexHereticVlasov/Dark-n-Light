using UnityEngine;
using UnityEngine.Events;

public sealed class PlayerUIPresenter : MonoBehaviour
{
    [SerializeField] private Player _player;

    public event UnityAction<Elements> PlayerDeterminated;
    public event UnityAction<float> ValueChanged;

    public void Init(Player player)
    {
        _player = player;
        _player.HealthChanged += OnHealthChanged;
        PlayerDeterminated?.Invoke(_player.Element);
    }

    private void OnDisable() => _player.HealthChanged -= OnHealthChanged;

    private void OnHealthChanged(float current, float max)
    {
        float value = current / max;
        ValueChanged?.Invoke(value);
    }
}
