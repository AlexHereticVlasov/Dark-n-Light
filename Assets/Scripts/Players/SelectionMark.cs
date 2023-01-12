using UnityEngine;

public class SelectionMark : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnEnable()
    {
        _player.Selected += OnSelected;
        _player.Deselected += OnDeselected;
        _player.Death += OnDeselected;
    }

    private void OnDisable()
    {
        _player.Selected -= OnSelected;
        _player.Deselected -= OnDeselected;
        _player.Death -= OnDeselected;
    }

    private void OnDeselected() => _renderer.enabled = false;

    private void OnSelected() => _renderer.enabled = true;
}
