using UnityEngine;

public class LeverView : MonoBehaviour
{
    private bool _isActive;

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Interactable _interactable;

    private void OnEnable() => _interactable.Interacted += OnInteracted;

    private void OnDisable() => _interactable.Interacted -= OnInteracted;

    private void OnInteracted()
    {
        _isActive = !_isActive;
        _renderer.color = _isActive ? Color.magenta : Color.white;
    }
}
